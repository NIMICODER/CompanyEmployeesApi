using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
              FindByCondition(x => ids.Contains(x.Id), trackChanges)
              .ToList();


        public Company GetCompany(Guid companyId, bool trackChanges) =>
             FindByCondition(c => c.Id.Equals(companyId), trackChanges)
             .SingleOrDefault();

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
         await FindAll(trackChanges)
         .OrderBy(c => c.Name)
         .ToListAsync();
        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
         await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
         .SingleOrDefaultAsync();
        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool
        trackChanges) =>
         await FindByCondition(x => ids.Contains(x.Id), trackChanges)
         .ToListAsync();



        //public IEnumerable<Company> GetAllCompaniesB(bool trackChanges)
        //{
        //    var companiesQuery = FindAll(trackChanges)
        //        .OrderBy(c => c.Name)
        //        .ToList();
        //    return companiesQuery;


        //}
    }
}
