using System.Collections;
using System.Collections.Generic;

namespace ToDo.Services.ToDoAPI.Models
{
    public class Status
    {
        public int Status_Id { get; set; }
        public string StatusName { get; set; }
        public virtual IEnumerable<TaskOrder> Tasks { get; set; }
    }
}
