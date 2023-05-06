using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.ComponentModel;
using System.Dynamic;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        
private readonly IDataShaper<EmployeeDto> _dataShaper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper, IDataShaper<EmployeeDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;

        }





        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)

        {
            await CheckIfCompanyExists(companyId, trackChanges);
            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);
            _repository.Employee.DeleteEmployee(employeeDb);

            await _repository.SaveAsync();

        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id,
            trackChanges);
            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }


        // map the employee entity to the EmployeeForUpdateDto type and return both
        //objects(employeeToPatch and employeeEntity) inside the Tuple to the controller
        //public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        //{
        //    var company = _repository.Company.GetCompanyAsync(companyId, compTrackChanges);
        //    if (company is null)
        //        throw new CompanyNotFoundException(companyId);
        //    var employeeEntity = _repository.Employee.GetEmployee(companyId, id,
        //    empTrackChanges);
        //    if (employeeEntity is null)
        //        throw new EmployeeNotFoundException(companyId);
        //    var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);
        //    return (employeeToPatch, employeeEntity);
        //}


        public async Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesAsync (Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            if (!employeeParameters.ValidAgeRange)
                throw new MaxAgeRangeBadRequestException();
            await CheckIfCompanyExists(companyId, trackChanges);
            var employeesWithMetaData = await _repository.Employee
            .GetEmployeesAsync(companyId, employeeParameters, trackChanges);
            var employeesDto =
            _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            var shapedData = _dataShaper.ShapeData(employeesDto,
employeeParameters.Fields);
            return (employees: shapedData, metaData: employeesWithMetaData.MetaData);
        }


        // maps from emplyeeToPatch to employeeEntity and calls the repository's Save method
        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            _repository.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync (Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id,
            empTrackChanges);
            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeDb);
            return (employeeToPatch: employeeToPatch, employeeEntity: employeeDb);
        }


        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id,
            empTrackChanges);
            _mapper.Map(employeeForUpdate, employeeDb);
            await _repository.SaveAsync();
        }



        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool trackChanges)
        {
            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id,
            trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);
            return employeeDb;
        }
    }

}
