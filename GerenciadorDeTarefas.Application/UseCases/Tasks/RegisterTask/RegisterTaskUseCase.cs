using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Responses;

namespace GerenciadorDeTarefas.Application.UseCases.Tasks.RegisterTask;

public class RegisterTaskUseCase
{
    public ResponseCreateTaskJson Execute(RequestTaskJson request)
    {
        return new ResponseCreateTaskJson()
        {
            Id = request.Id,
            Name = request.Name,
        };
    }

}