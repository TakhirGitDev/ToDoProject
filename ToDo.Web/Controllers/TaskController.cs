using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<List<StatusDto>> Statuses()
        {
            List<StatusDto> statuses = new List<StatusDto>();

            var response_statuses = await _service.GetStatusesAsync<ResponseDto>();
            if (response_statuses != null && response_statuses.IsSuccess)
            {
                statuses = JsonConvert.DeserializeObject<List<StatusDto>>(Convert.ToString(response_statuses.Result));
            }
            return statuses;
        }
        public async Task<IActionResult> TaskIndex()
        {
            List<TaskDto> tasks = new List<TaskDto>();

            ViewBag.Stats = new SelectList(await Statuses(), "Status_Id", "StatusName");

            var response_tasks = await _service.GetTasksAsync<ResponseDto>();
            if (response_tasks != null && response_tasks.IsSuccess)
            {
                tasks = JsonConvert.DeserializeObject<List<TaskDto>>(Convert.ToString(response_tasks.Result));
            }
            //var tupleModel = new Tuple<List<TaskDto>, List<StatusDto>>(tasks, statuses);
            return View(tasks);
        }

        public async Task<IActionResult> TaskCreate()
        {

            ViewBag.Stats = new SelectList(await Statuses(), "Status_Id", "StatusName");
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
            ViewBag.Stats = new SelectList(await Statuses(), "Status_Id", "StatusName");
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
            ViewBag.Stats = new SelectList(await Statuses(), "Status_Id", "StatusName");
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
