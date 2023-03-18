using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
             FindByCondition(c => c.Id.Equals(companyId), trackChanges)
             .SingleOrDefault();


        //public IEnumerable<Company> GetAllCompaniesB(bool trackChanges)
        //{
        //    var companiesQuery = FindAll(trackChanges)
        //        .OrderBy(c => c.Name)
        //        .ToList();
        //    return companiesQuery;


        //}
    }
}
