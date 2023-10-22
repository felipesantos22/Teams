using futebol.Data;
using futebol.Entities;

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
        await _dataContext.Teams.AddAsync(team);
        await _dataContext.SaveChangesAsync();
        return team;
    }
}