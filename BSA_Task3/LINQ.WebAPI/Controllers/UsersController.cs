using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LINQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _service;
        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return Ok(await new Task<IEnumerable<UserDTO>>(() => _service.Read()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return Ok(await new Task<UserDTO>(() => _service.ReadById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO User)
        {
            await new Task(() => _service.Create(User));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO newUser)
        {
            await new Task(() => _service.Update(newUser, id));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await new Task(() => _service.Delete(id));
            return Ok();
        }
    }
}
