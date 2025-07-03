using TaskApi.Models;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        List<UserTask> GetAllTasks();
        void AddTask(UserTask task);
        bool DeleteTask(int id);
    }
}
