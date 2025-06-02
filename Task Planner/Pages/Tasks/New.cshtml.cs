using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Planner.Models;
using Task_Planner.Services;

namespace Task_Planner.Pages.Tasks
{
    public class NewModel : PageModel
    {
        private readonly ITaskService _taskService;

        public NewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public UserTask Task { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _taskService.CreateTask(Task);
            return RedirectToPage("/Index");
        }
    }
}
