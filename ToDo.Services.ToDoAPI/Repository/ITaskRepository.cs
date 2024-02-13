using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Services.ToDoAPI.Models.Dtos;

namespace ToDo.Services.ToDoAPI.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDto>> GetTasks();
        Task<TaskDto> GetTaskById(int taskId);
        Task<TaskDto> CreateUpdateTask(TaskDto taskDto);
        Task<bool> DeleteTask(int taskId);
    }
}
