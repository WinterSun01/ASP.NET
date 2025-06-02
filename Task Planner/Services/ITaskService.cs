using System.Collections.Generic;
using Task_Planner.Models;

namespace Task_Planner.Services
{
    public interface ITaskService
    {
        void CreateTask(UserTask task);
        List<UserTask> GetAllTasks();
        UserTask? GetTaskById(int id);
        void DeleteTask(int id);
        void UpdateTask(UserTask task);
    }
}
