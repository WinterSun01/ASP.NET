using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Models;
using TaskManager.Services;
using System.Collections.Generic;

namespace TaskManager.Pages
{
    public class TasksModel : PageModel
    {
        private readonly ITaskService _taskService;

        public TasksModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public List<UserTask> Tasks { get; set; }

        public void OnGet()
        {
            Tasks = _taskService.GetAllTasks();
        }
    }
}

