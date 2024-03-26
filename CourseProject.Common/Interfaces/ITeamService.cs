using CourseProject.Common.Dtos.Teams;
using CourseProject.Common.Model;

namespace CourseProject.Common.Interfaces;

public interface ITeamService
{
    Task<int> CreateTeamAsync(TeamCreate teamCreate);
    Task UpdateTeamAsync(TeamUpdate teamUpdate);
    Task<List<TeamGet>> GetTeamsAsync();
    Task<TeamGet> GetTeamAsync(int Id);
    Task DeleteTeamAsync(TeamDelete teamDelete);
}
