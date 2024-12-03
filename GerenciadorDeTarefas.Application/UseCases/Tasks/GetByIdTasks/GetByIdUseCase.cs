using GerenciadorDeTarefas.Communication.Responses;

namespace GerenciadorDeTarefas.Application.UseCases.Tasks.GetByIdTasks;

public class GetByIdUseCase
{
    public ResponseGetByIdJson Execute(int id)
    {
        return new ResponseGetByIdJson
        {
            Id = id,
            Name = "Cozinhar",
            Description = "Fazer Almoço",
            FinishDate = new DateTime(2024, 12, 03, 12, 43, 0),
            Priority = 0,
            Status = 0
            
        };
    }
}