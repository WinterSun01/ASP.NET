using System.Collections.Generic;
using RazorPagesWithAdmin.Models;

namespace RazorPagesWithAdmin.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks = new();

        public List<UserTask> GetAllTasks()
        {
            return _tasks;
        }

        public void CreateTask(UserTask task)
        {
            _tasks.Add(task);
        }
    }
}
