using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Planner.Models;
using Task_Planner.Services;

namespace Task_Planner.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskService _taskService;

        public EditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public UserTask Task { get; set; }

        public IActionResult OnGet(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound();

            Task = task;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _taskService.UpdateTask(Task);
            return RedirectToPage("/Tasks/List");
        }
    }
}
