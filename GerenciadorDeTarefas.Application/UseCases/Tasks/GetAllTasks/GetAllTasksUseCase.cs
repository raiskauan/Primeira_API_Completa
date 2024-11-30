using GerenciadorDeTarefas.Communication.Responses;

namespace GerenciadorDeTarefas.Application.UseCases.Tasks.GetAllTasks;

public class GetAllTasksUseCase
{
    public ResponseGetAllTasksJson Execute()
    {
        return new ResponseGetAllTasksJson()
        {
            Tasks = new List<ResponseCreateTaskJson>()
            {

                new ResponseCreateTaskJson()
                {
                    Id = 1, Name = "Tarefa 1",
                },
                
                new ResponseCreateTaskJson()
                {
                    Id = 2, Name = "Tarefa 2",
                },
                
                new ResponseCreateTaskJson()
                {
                    Id = 3, Name = "Tarefa 3",
                }
            }
        };



    }
}