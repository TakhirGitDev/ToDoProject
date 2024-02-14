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

    
    public class TaskController : Controller
    {
        protected ResponseDto _responseDto;
        private ITaskRepository _taskRepository;
        private IStatusRepository _statusRepository;
        public TaskController(ITaskRepository taskRepository, IStatusRepository statusRepository)
        {
            _taskRepository = taskRepository;
            _statusRepository = statusRepository;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        [Route("api/tasks")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<TaskDto> taskDtos = await _taskRepository.GetTasks();
                _responseDto.Result = taskDtos;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpGet]
        [Route("api/statuses")]
        public async Task<object> GetStatuses()
        {
            try
            {
                IEnumerable<StatusDto> statusDtos = await _statusRepository.GetStatuses();
                _responseDto.Result = statusDtos;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;

        }

        [HttpGet]
        [Route("api/tasks/{id}")]
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
        [Route("api/tasks")]
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
        [Route("api/tasks")]
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
        [Route("api/tasks/{id}")]
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
