using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesWithAdmin.Models;
using RazorPagesWithAdmin.Services;

namespace RazorPagesWithAdmin.Pages.Tasks
{
    public class NewTaskModel : PageModel
    {
        private readonly ITaskService _taskService;

        public NewTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public UserTask Task { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _taskService.CreateTask(Task);
            return RedirectToPage("/Index"); // можно заменить на страницу со списком задач
        }
    }
}
