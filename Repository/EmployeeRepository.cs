using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        //public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
        //    FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
        //    .SingleOrDefault();
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
        await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();


        //public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
        //    FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        //    .OrderBy(e => e.Name).ToList();

        //    public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId,  bool trackChanges) =>
        //await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        //    .OrderBy(e => e.Name)
        //    .ToListAsync();

        //public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges) =>
        //  await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        //   .OrderBy(e => e.Name)
        //   .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
        //   .Take(employeeParameters.PageSize)
        //   .ToListAsync();

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges) 
        { 
         var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
          .OrderBy(e => e.Name)
          .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
          .Take(employeeParameters.PageSize)
          .ToListAsync();

         var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .CountAsync();

            return new PagedList<Employee>(employees, count,
            employeeParameters.PageNumber, employeeParameters.PageSize);
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
           Delete(employee);
        }

      

    }
}
