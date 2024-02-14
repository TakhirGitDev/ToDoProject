using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Web.Models;
using ToDo.Web.Services.IServices;

namespace ToDo.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IToDoService _service;
        public TaskController(IToDoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> TaskIndex()
        {
            List<TaskDto> tasks = new List<TaskDto>();
            var response = await _service.GetTasksAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                tasks = JsonConvert.DeserializeObject<List<TaskDto>>(Convert.ToString(response.Result));
            }
            return View(tasks);
        }

        public async Task<IActionResult> TaskCreate()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaskCreate(TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateTaskAsync<ResponseDto>(taskDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(TaskIndex));
                }

            }
            return View(taskDto);
        }

        public async Task<IActionResult> TaskEdit(int Id)
        {
            var response = await _service.GetTaskByIdAsync<ResponseDto>(Id);
            if (response != null && response.IsSuccess)
            {
                TaskDto tasks = JsonConvert.DeserializeObject<TaskDto>(Convert.ToString(response.Result));
                return View(tasks);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaskEdit(TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateTaskAsync<ResponseDto>(taskDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(TaskIndex));
                }

            }
            return View(taskDto);
        }

        public async Task<IActionResult> TaskDelete(int Id)
        {
            var response = await _service.GetTaskByIdAsync<ResponseDto>(Id);
            if (response != null && response.IsSuccess)
            {
                TaskDto tasks = JsonConvert.DeserializeObject<TaskDto>(Convert.ToString(response.Result));
                return View(tasks);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaskDelete(TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.DeleteTaskAsync<ResponseDto>(taskDto.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(TaskIndex));
                }

            }
            return View(taskDto);
        }



    }
}
