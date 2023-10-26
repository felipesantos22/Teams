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
}