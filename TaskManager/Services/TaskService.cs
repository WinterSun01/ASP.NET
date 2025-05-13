using TaskManager.Models;
using System.Collections.Generic;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        public List<UserTask> GetAllTasks()
        {
            return new List<UserTask>
            {
                new UserTask { Title = "Библиотека", Description = "Отнести книгу в библиотеку" },
                new UserTask { Title = "Купить продукты", Description = "Купить молоко, хлеб, макароны" },
                new UserTask { Title = "Домашнее задание", Description = "Сделать домашнее задание по ASP.NET Core" }
            };
        }
    }
}

