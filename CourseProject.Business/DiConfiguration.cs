using CourseProject.Business.Services;
using CourseProject.Business.Validation;
using CourseProject.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CourseProject.Business;

public class DiConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ITeamService, TeamService>();

        services.AddScoped<AddressCreateValidator, AddressCreateValidator>();
        services.AddScoped<AddressUpdateValidator, AddressUpdateValidator>();
        services.AddScoped<EmployeeCreateValidator, EmployeeCreateValidator>();
        services.AddScoped<EmployeeUpdateValidator, EmployeeUpdateValidator>();
        services.AddScoped<JobCreateValidator, JobCreateValidator>();
        services.AddScoped<JobUpdateValidator, JobUpdateValidator>();
        services.AddScoped<TeamCreateValidator, TeamCreateValidator>();
        services.AddScoped<TeamUpdateValidator, TeamUpdateValidator>();

    }
}
