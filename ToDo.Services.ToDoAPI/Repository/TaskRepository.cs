using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ToDo.Services.ToDoAPI.DbContexts;
using ToDo.Services.ToDoAPI.Models;
using ToDo.Services.ToDoAPI.Models.Dtos;

namespace ToDo.Services.ToDoAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoDbContext _dbContext;
        private IMapper _mapper;

        public TaskRepository(ToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TaskDto> CreateUpdateTask(TaskDto taskDto)
        {
            TaskOrder task = _mapper.Map<TaskDto, TaskOrder>(taskDto);
            if (task.Id > 0)
            {
                _dbContext.Tasks.Update(task);
            }
            else
            {
                _dbContext.Tasks.Add(task);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TaskOrder, TaskDto>(task);
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            try
            {
                TaskOrder task = await _dbContext.Tasks.FirstOrDefaultAsync(u=> u.Id == taskId);
                if (task == null) 
                { 
                    return false;
                }
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public async Task<TaskDto> GetTaskById(int taskId)
        {
            TaskOrder task = await _dbContext.Tasks.Where(x=>x.Id == taskId).FirstOrDefaultAsync();
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            IEnumerable<TaskOrder> taskList = (IEnumerable<TaskOrder>)await _dbContext.Tasks.ToListAsync();
            return _mapper.Map<List<TaskDto>>(taskList);
        }
    }
}
