using TaskApi.Models;

namespace TaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;
        private int _nextId = 3;

        public TaskService()
        {
            _tasks = new List<UserTask>
            {
                new UserTask { Id = 1, Title = "Buy groceries", Description = "Milk, Bread, Eggs" },
                new UserTask { Id = 2, Title = "Study", Description = "ASP.NET Core Web API tutorial" }
            };
        }

        public List<UserTask> GetAllTasks()
        {
            return _tasks;
        }

        public void AddTask(UserTask task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;

            _tasks.Remove(task);
            return true;
        }
    }
}
