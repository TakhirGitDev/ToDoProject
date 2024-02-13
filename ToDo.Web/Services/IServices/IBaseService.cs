using System;
using System.Threading.Tasks;
using ToDo.Web.Models;
using ToDo.Web.Models.Dtos;

namespace ToDo.Web.Services.IServices
{
    public interface IBaseService: IDisposable
    {
        ResponseDto responseModel { get; set; }    
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
