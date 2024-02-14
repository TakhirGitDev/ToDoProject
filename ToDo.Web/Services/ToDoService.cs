using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Services
{
    public class ToDoService : BaseService, IToDoService
    {
        private readonly IHttpClientFactory _httpClient;
        public ToDoService(IHttpClientFactory httpClient): base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateTaskAsync<T>(TaskDto taskDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = taskDto,
                ApiUrl = SD.ToDoAPIBase + "/api/tasks"
            });

        }

        public async Task<T> DeleteTaskAsync<T>(int taskId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.ToDoAPIBase + "/api/tasks/"+taskId
            });
        }

        public async Task<T> GetTaskByIdAsync<T>(int taskId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ToDoAPIBase + "/api/tasks/"+taskId
            });
        }

        public async Task<T> GetTasksAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.ToDoAPIBase + "/api/tasks"
            });
        }

        public async Task<T> UpdateTaskAsync<T>(TaskDto taskDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = taskDto,
                ApiUrl = SD.ToDoAPIBase + "/api/tasks"
            });
        }
    }
}
