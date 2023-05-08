using Contracts;
using Entities.LinkModels;
using Shared.DataTransferObjects;


namespace CompanyEmployeesApi.Utility
{
    public class EmployeeLinks : IEmployeeLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<EmployeeDto> _dataShaper;
        public EmployeeLinks(LinkGenerator linkGenerator, IDataShaper<EmployeeDto>
       dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }


        public LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto, string
fields, Guid companyId, HttpContext httpContext)
        {
            var shapedEmployees = ShapeData(employeesDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkdedEmployees(employeesDto, fields, companyId, httpContext,
               shapedEmployees);
            return ReturnShapedEmployees(shapedEmployees);
        }



    }
}
