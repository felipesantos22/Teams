using futebol.Entities;
using futebol.Repository;
using Microsoft.AspNetCore.Mvc;

namespace futebol.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly TeamRepository _teamRepository;

    public TeamController(TeamRepository teamRepository)
    {
        this._teamRepository = teamRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Team>> Create([FromBody] Team team)
    {
        var newTeam = await _teamRepository.Create(team);
        return Ok(newTeam);
    }
}