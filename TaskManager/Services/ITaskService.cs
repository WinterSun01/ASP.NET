﻿using TaskManager.Models;
using System.Collections.Generic;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        List<UserTask> GetAllTasks();
    }
}

