using AutoMapper;
using CourseProject.Common.Dtos.Address;
using CourseProject.Common.Dtos.Employee;
using CourseProject.Common.Dtos.Job;
using CourseProject.Common.Dtos.Teams;
using CourseProject.Common.Model;

namespace CourseProject.Business;

public class DtoEntityMapperProfile : Profile
{
	public DtoEntityMapperProfile()
	{
        CreateMap<Common.Dtos.Address.AddressCreate, Address>()
			.ForMember(dest => dest.Id, opt => opt.Ignore());
		CreateMap<AddressUpdate, Address>();
		CreateMap<Address, AddressGet>();

        CreateMap<Common.Dtos.Job.JobCreate, Job>()
			.ForMember(dest => dest.Id, opt => opt.Ignore());
		CreateMap<JobUpdate, Job>();
		CreateMap<Job, JobGet>();

		CreateMap<EmployeeCreate, Employee>()
			.ForMember(dest => dest.Id, opt => opt.Ignore())
			.ForMember(dest => dest.Teams, opt => opt.Ignore())
            .ForMember(dest => dest.Job, opt => opt.Ignore());

        CreateMap<EmployeeUpdate, Employee>()
            .ForMember(dest => dest.Teams, opt => opt.Ignore())
            .ForMember(dest => dest.Job, opt => opt.Ignore());

        CreateMap<Employee, EmployeeDetails>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            //.ForMember(dest => dest.Teams, opt => opt.Ignore()) //todo: add teams
            .ForMember(dest => dest.Job, opt => opt.Ignore())
            .ForMember(dest => dest.Address, opt => opt.Ignore());

        CreateMap<Employee, EmployeeList>();

        CreateMap<TeamCreate, Team>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Employees, opt => opt.Ignore());

        CreateMap<TeamUpdate, Team>()
          .ForMember(dest => dest.Employees, opt => opt.Ignore());
        CreateMap<Team, TeamGet>();
    }
}
