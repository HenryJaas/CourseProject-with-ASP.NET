using CourseProject.Common.Dtos.Employee;

namespace CourseProject.Common.Dtos.Teams;

public record TeamGet(int Id, string Name, List<EmployeeList> Employees);