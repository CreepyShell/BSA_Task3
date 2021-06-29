using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty Tasks, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LINQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TaskService _service;
        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> Get()
        {
            return Ok(await new Task<IEnumerable<TaskDTO>>(() => _service.Read()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> Get(int id)
        {
            return Ok(await new Task<TaskDTO>(() => _service.ReadById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDTO Task)
        {
            await new Task(() => _service.Create(Task));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskDTO newTask)
        {
            try
            {
                await new Task(() => _service.Update(newTask, id));
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
                return Ok();
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        }
    }
}
