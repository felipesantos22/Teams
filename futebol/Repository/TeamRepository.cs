using futebol.Data;
using futebol.Entities;
using Microsoft.EntityFrameworkCore;

namespace futebol.Repository;

public class TeamRepository
{
    private readonly DataContext _dataContext;

    public TeamRepository(DataContext context)
    {
        _dataContext = context;
    }

    public async Task<Team> Create(Team team)
    {
        await _dataContext.team.AddAsync(team);
        await _dataContext.SaveChangesAsync();
        return team;
    }

    public async Task<Team?> Details(int id)
    {
        var userId = await _dataContext.team.FirstOrDefaultAsync(x => x.Id == id);
        return userId;
    }

    public async Task<List<Team>> FindAll()
    {
        var teams = await _dataContext.team.ToListAsync();
        return teams;
    }

    public async Task<Team> UpdateTeam(int id, Team team)
    {
        var existingTeam = await _dataContext.team.FirstOrDefaultAsync(t => t.Id == id);
        existingTeam!.TeamName = team.TeamName;
        await _dataContext.SaveChangesAsync();
        return existingTeam;
    }

    public async Task<Team> DeleteTeam(int id)
    {
        var deleteTeam = await _dataContext.team.FirstOrDefaultAsync(t => t.Id == id);
        _dataContext.team.Remove(deleteTeam!);
        await _dataContext.SaveChangesAsync();
        return deleteTeam!;
    }
}