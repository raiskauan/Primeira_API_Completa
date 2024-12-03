using GerenciadorDeTarefas.Application.UseCases.Tasks.DeleteTask;
using GerenciadorDeTarefas.Application.UseCases.Tasks.GetAllTasks;
using GerenciadorDeTarefas.Application.UseCases.Tasks.GetByIdTasks;
using GerenciadorDeTarefas.Application.UseCases.Tasks.RegisterTask;
using GerenciadorDeTarefas.Application.UseCases.Tasks.UpdateTask;
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
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseGetByIdJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetById(int id)
        {
            var useCase = new GetByIdUseCase();
            
            var response = useCase.Execute(id);
            
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateTaskJson request)
        {
            var useCase = new UpdateTaskUseCase();
            
            useCase.Execute(id, request);
            
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var useCase = new DeleteTaskByIdUseCase();
            
            useCase.Execute(id);
            
            return NoContent();
        }
        
    }
    
    
}
