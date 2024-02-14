using System.Threading.Tasks;
using ToDo.Web.Models;

namespace ToDo.Web.Services.IServices
{
    public interface IToDoService: IBaseService
    {
        Task<T> GetStatusesAsync<T>();
        Task<T> GetTasksAsync<T>();
        Task<T> GetTaskByIdAsync<T>(int taskId);
        Task<T> CreateTaskAsync<T>(TaskDto taskDto);
        Task<T> UpdateTaskAsync<T>(TaskDto taskDto);
        Task<T> DeleteTaskAsync<T>(int taskId);
    }
}
