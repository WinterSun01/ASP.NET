using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserTask>> GetAll()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult AddTask([FromBody] UserTask newTask)
        {
            _taskService.AddTask(newTask);
            return CreatedAtAction(nameof(GetAll), new { id = newTask.Id }, newTask);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var result = _taskService.DeleteTask(id);
            if (!result)
            {
                return NotFound($"Task with Id {id} not found.");
            }
            return NoContent();
        }
    }
}
