﻿namespace ToDo.Services.ToDoAPI.Models
{
    public class TaskOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
