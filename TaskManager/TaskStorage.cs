using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    public interface ITaskStorage
    {
        public void AddTask(ITask task);
        public Dictionary<int, ITask> GetAllTasks();
        public ITask GetTask(int id);
        public void DeleteTask(int id);
        public void UpdateTask(int id, string newTask);
        public void CompleteTask(int id);
    }
    public class MemoryTaskStorage: ITaskStorage
    {
        public Dictionary<int,ITask> tasks = new Dictionary<int, ITask>();
        private int _taskCount=1;

        public void AddTask(ITask task)
        {
            try 
            {
                int taskId = _taskCount;
                tasks.Add(taskId, task);
            }
            catch
            {
                throw new Exception("There was an error adding the task.");
            }
            _taskCount += 1;
        }
        public Dictionary<int, ITask> GetAllTasks()
        {
            return tasks;
        }
        public void DeleteTask(int id)
        {
            if (tasks.Count == 0)
            {
                throw new Exception("There's no tasks available.");
            }
            try 
            {
                tasks.Remove(id);
            }
            catch
            {
                throw new Exception("There was an error removing the task.");
            }

        }
        public ITask GetTask(int id)
        {
            ITask task;
            if (tasks.Count == 0)
            {
                throw new Exception("There's no tasks available.");
            }
            try
            {
                task = tasks[id];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Incorrect ID.");
            }
            return task;
        }
        public void UpdateTask(int id, string newTask)
        {
            if (tasks.Count == 0)
            {
                throw new Exception("There's no tasks available.");
            }
            try
            {
                tasks[id].UpdateTask(newTask);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Incorrect ID.");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void CompleteTask(int id)
        {
            if (tasks.Count == 0)
            {
                throw new Exception("There's no tasks available.");
            }
            try
            {
                tasks[id].CompleteTask();
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Incorrect ID.");
            }
        }

    }
}
