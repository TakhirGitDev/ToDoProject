using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Services.ToDoAPI.Models;
using ToDo.Services.ToDoAPI.Models.Dtos;
using ToDo.Services.ToDoAPI.Repository;

namespace ToDo.Services.ToDoAPI.Controllers
{

    [Route("api/tasks")]
    public class TaskController : Controller
    {
        protected ResponseDto _responseDto;
        private ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<TaskDto> taskDtos = await _taskRepository.GetTasks();
                _responseDto.Result = taskDtos;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess= false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                TaskDto task = await _taskRepository.GetTaskById(id);
                _responseDto.Result = task;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpPost]
        public async Task<object> Post([FromBody] TaskDto taskDto)
        {
            try
            {
                TaskDto model = await _taskRepository.CreateUpdateTask(taskDto);
                _responseDto.Result = model;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpPut]
        public async Task<object> Put([FromBody] TaskDto taskDto)
        {
            try
            {
                TaskDto model = await _taskRepository.CreateUpdateTask(taskDto);
                _responseDto.Result = model;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _taskRepository.DeleteTask(id);
                _responseDto.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }


    }
}
