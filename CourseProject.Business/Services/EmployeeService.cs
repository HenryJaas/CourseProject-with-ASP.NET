using AutoMapper;
using CourseProject.Business.Exceptions;
using CourseProject.Business.Validation;
using CourseProject.Common.Dtos.Employee;
using CourseProject.Common.Interfaces;
using CourseProject.Common.Model;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IGenericRepository<Employee> EmployeeRepository { get; }
    public IGenericRepository<Job> JobRepository { get; }
    public IGenericRepository<Address> AddressRepository { get; }
    private IMapper Mapper { get; }
    private EmployeeCreateValidator EmployeeCreateValidator { get; }
    private EmployeeUpdateValidator EmployeeUpdateValidator { get; }

    public EmployeeService(IGenericRepository<Employee> employeeRepository,IGenericRepository<Job> jobRepository,
        IGenericRepository<Address> addressRepository, IMapper mapper, EmployeeCreateValidator employeeCreateValidator,
        EmployeeUpdateValidator employeeUpdateValidator)
    {
        EmployeeRepository = employeeRepository;
        JobRepository = jobRepository;
        AddressRepository = addressRepository;
        Mapper = mapper;
        EmployeeCreateValidator = employeeCreateValidator;
        EmployeeUpdateValidator = employeeUpdateValidator;
    }

    public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
    {
        await EmployeeCreateValidator.ValidateAndThrowAsync(employeeCreate);

        var address = await AddressRepository.GetByIdAsync(employeeCreate.AddressId);

        if (address == null)
            throw new AddressNotFoundException(employeeCreate.AddressId);

        var job = await JobRepository.GetByIdAsync(employeeCreate.JobId);

        if (job == null)
            throw new JobNotFoundException(employeeCreate.JobId);

        var entity = Mapper.Map<Employee>(employeeCreate);
        entity.Address = address;
        entity.Job = job;
        await EmployeeRepository.insertAsync(entity);
        await EmployeeRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteEmployeeAsync(EmployeeDelete employeeDelete)
    {
        var entity = await EmployeeRepository.GetByIdAsync(employeeDelete.Id);

        if (entity == null)
            throw new EmployeeNotFoundException(employeeDelete.Id);

        EmployeeRepository.Delete(entity);
        await EmployeeRepository.SaveChangesAsync();
    }

    public async Task<EmployeeDetails> GetEmployeeAsync(int id)
    {
        var entity = await EmployeeRepository.GetByIdAsync(id, (employee) => employee.Address, (employee) => employee.Job,(employee) => employee.Teams);

        if (entity == null)
            throw new EmployeeNotFoundException(id);

        return Mapper.Map<EmployeeDetails>(entity);
    }

    public async Task<List<EmployeeList>> GetEmployeesAsync(EmployeeFilter employeeFilter)
    {
        Expression<Func<Employee, bool>> firstNameFilter = (employee) => employeeFilter.FirstName == null ? true :
        employee.FirstName.StartsWith(employeeFilter.FirstName);
        Expression<Func<Employee, bool>> lastNameFilter = (employee) => employeeFilter.LastName == null ? true :
        employee.LastName.StartsWith(employeeFilter.LastName);
        Expression<Func<Employee, bool>> jobFilter = (employee) => employeeFilter.Job == null ? true :
        employee.Job.Name.StartsWith(employeeFilter.Job);
        Expression<Func<Employee, bool>> teamFilter = (employee) => employeeFilter.Team == null ? true :
        employee.Teams.Any(team => team.Name.StartsWith(employeeFilter.Team));

        var entities = await EmployeeRepository.GetFilteredAsync(new Expression<Func<Employee, bool>>[]
        {
            firstNameFilter, lastNameFilter, jobFilter, teamFilter
        }, employeeFilter.Skip, employeeFilter.Take,
        (employee) => employee.Address, (employee) => employee.Job, (employee) => employee.Teams);

        return Mapper.Map<List<EmployeeList>>(entities);
    }

    public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
    {
        await EmployeeUpdateValidator.ValidateAndThrowAsync(employeeUpdate);

        var address = await AddressRepository.GetByIdAsync(employeeUpdate.AddressId);

        if (address == null)
            throw new AddressNotFoundException(employeeUpdate.AddressId);

        var job = await JobRepository.GetByIdAsync(employeeUpdate.JobId);

        if (job == null)
            throw new JobNotFoundException(employeeUpdate.JobId);

        var existingEmployee = await EmployeeRepository.GetByIdAsync(employeeUpdate.Id);

        if (existingEmployee == null)
            throw new EmployeeNotFoundException(employeeUpdate.Id);

        var entity = Mapper.Map<Employee>(employeeUpdate);
        entity.Address = address;
        entity.Job = job;
        EmployeeRepository.Update(entity);
        await EmployeeRepository.SaveChangesAsync();
    }
}
