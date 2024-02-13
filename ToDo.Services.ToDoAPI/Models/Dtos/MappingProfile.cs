using AutoMapper;

namespace ToDo.Services.ToDoAPI.Models.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDto, TaskOrder>().ReverseMap();
            CreateMap<StatusDto, Status>().ReverseMap();
            
        }
    }
}
