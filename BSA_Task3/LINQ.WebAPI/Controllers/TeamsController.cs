using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LINQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private TeamService _service;
        public TeamsController(TeamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> Get()
        {
            return Ok(await new Task<IEnumerable<TeamDTO>>(() => _service.Read()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> Get(int id)
        {
            return Ok(await new Task<TeamDTO>(() => _service.ReadById(id)));
        }

        [HttpPost]
        public async Task Post([FromBody] TeamDTO Team)
        {
            await new Task(() => _service.Create(Team));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TeamDTO newTeam)
        {
            try
            {
                await new Task(() => _service.Update(newTeam, id));
                return Ok();
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await new Task(() => _service.Delete(id));
                return NoContent();
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        }
    }
}
