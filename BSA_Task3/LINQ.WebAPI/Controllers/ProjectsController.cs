﻿using AutoMapper;
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
    public class ProjectsController : ControllerBase
    {
        private ProjectService _service;
        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectDTO>> Get()
        {
            return await new Task<IEnumerable<ProjectDTO>>(() => _service.Read());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> Get(int id)
        {
            try
            {
                return Ok(await new Task<ProjectDTO>(() => _service.ReadById(id)));
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectDTO project)
        {
            try
            {
                await new Task(() => _service.Create(project));
                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectDTO newProject)
        {
            try
            {
                await new Task(() => _service.Update(newProject, id));
                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await new Task(() => _service.Delete(id));
                return Ok();
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }        }
    }
}
