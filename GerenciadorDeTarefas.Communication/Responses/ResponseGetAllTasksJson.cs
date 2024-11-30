namespace GerenciadorDeTarefas.Communication.Responses;

public class ResponseGetAllTasksJson
{
    public List<ResponseCreateTaskJson> Tasks { get; set; } = [];
}