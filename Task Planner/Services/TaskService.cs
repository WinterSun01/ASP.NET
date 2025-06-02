using System.Collections.Generic;
using Task_Planner.Models;

namespace Task_Planner.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks = new();
        private int _nextId = 1;

        public void CreateTask(UserTask task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public List<UserTask> GetAllTasks()
        {
            return _tasks;
        }
    }
}
