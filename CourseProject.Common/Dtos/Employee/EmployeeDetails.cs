using CourseProject.Common.Dtos.Address;
using CourseProject.Common.Dtos.Job;
using CourseProject.Common.Dtos.Teams;

namespace CourseProject.Common.Dtos.Employee;


public record EmployeeDetails(int Id, string FirstName, string LastName, AddressGet Address, JobGet Job, List<TeamGet> Teams);