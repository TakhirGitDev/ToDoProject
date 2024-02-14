using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Services.ToDoAPI.DbContexts;
using ToDo.Services.ToDoAPI.Models.Dtos;

namespace ToDo.Services.ToDoAPI.Repository
{
    public class StatusRepository: IStatusRepository
    {
        private readonly ToDoDbContext _dbContext;
        private IMapper _mapper;

        public StatusRepository(ToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<StatusDto>> GetStatuses()
        {
            //var statusList = _dbContext.Statuses.Select(x => new StatusDto()
            //{
            //    Status_Id = x.Status_Id,
            //    StatusName = x.StatusName

            //}).ToListAsync();


            var statusList = await _dbContext.Statuses.ToListAsync();
            return _mapper.Map<ICollection<StatusDto>>(statusList);
        }

    }
}
