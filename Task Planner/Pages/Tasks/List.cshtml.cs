using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Planner.Models;
using Task_Planner.Services;
using System.Collections.Generic;

namespace Task_Planner.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly ITaskService _taskService;

        public List<UserTask> Tasks { get; set; } = new();

        public ListModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {
            Tasks = _taskService.GetAllTasks();
        }
    }
}
