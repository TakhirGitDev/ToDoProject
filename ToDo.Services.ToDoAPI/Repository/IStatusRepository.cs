using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ToDo.Services.ToDoAPI.Models.Dtos;

namespace ToDo.Services.ToDoAPI.Repository
{
    public interface IStatusRepository
    {
        Task<ICollection<StatusDto>> GetStatuses();
    }
}
