﻿using GerenciadorDeTarefas.Application.UseCases.Tasks.GetAllTasks;
using GerenciadorDeTarefas.Application.UseCases.Tasks.RegisterTask;
using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), (StatusCodes.Status400BadRequest))]
        public IActionResult Create([FromBody] RequestTaskJson request)
        {
            var response = new RegisterTaskUseCase().Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetAllTasksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllTasksUseCase();
            
            var response = useCase.Execute();

            if (response.Tasks.Any())
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
    
    
}
