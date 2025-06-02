using System.Collections.Generic;
using RazorPagesWithAdmin.Models;

namespace RazorPagesWithAdmin.Services
{
    public interface ITaskService
    {
        List<UserTask> GetAllTasks();
        void CreateTask(UserTask task);
    }
}