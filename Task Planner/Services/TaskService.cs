using Task_Planner.Models;
using System.Collections.Generic;
using System.Linq;

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

        public List<UserTask> GetAllTasks() => _tasks;

        public UserTask? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                _tasks.Remove(task);
        }

        public void UpdateTask(UserTask updatedTask)
        {
            var existing = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existing != null)
            {
                existing.Title = updatedTask.Title;
                existing.Description = updatedTask.Description;
            }
        }
    }
}
