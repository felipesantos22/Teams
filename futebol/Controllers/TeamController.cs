using futebol.Entities;
using futebol.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
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

    
    

    [HttpGet("{id}")]
    public async Task<ActionResult<bool>> GetById(int id)
    {
        var team = await _teamRepository.Details(id);

        if (team == null)
        {
            return NotFound($"{{ \"message\": \"Time não encontrado\" }}");
        }

        return Ok(team);
    }

    
    
    

    [HttpGet]
    public async Task<ActionResult<List<Team>>> Index()
    {
        var teams = await _teamRepository.FindAll();
        return Ok(teams);
    }

    
    
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Team>> Update(int id, [FromBody] Team team)
    {
        var teamId = await _teamRepository.Details(id);
        if (teamId == null)
        {
            return NotFound($"{{ \"message\": \"Time não encontrado\" }}");
        }

        var teamUpdate = await _teamRepository.UpdateTeam(id, team);
        return Ok(teamUpdate);
    }

    
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Team>> Delete(int id)
    {
        var teamId = await _teamRepository.Details(id);
        if (teamId == null)
        {
            return NotFound($"{{ \"message\": \"Time não encontrado\" }}");
        }

        var deleteTeam = await _teamRepository.DeleteTeam(id);
        return Ok($"{{ \"message\": \"Team deleted\" }}");
    }



    [HttpGet("search")]
    public async Task<ActionResult<Team>> TeamName([FromQuery] string team)
    {
        var teamName = await _teamRepository.FindTeam(team);
        if (teamName == null)
        {
            return NotFound($"{{ \"message\": \"Time não encontrado\" }}");
        }
        return Ok(teamName);
    }
}