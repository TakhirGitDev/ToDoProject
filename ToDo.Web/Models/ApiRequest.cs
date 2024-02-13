using Microsoft.AspNetCore.Mvc;
using static ToDo.Web.SD;

namespace ToDo.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        
    }
}
