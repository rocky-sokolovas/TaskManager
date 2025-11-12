using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaskManager
{
    public class MainTaskManager(ITaskStorage storage, TaskFactory factory)
    {
        ITaskStorage Storage = storage;
        TaskFactory Factory = factory;

        public void AddTask(string type,string task)
        {
            Storage.AddTask(Factory.CreateTask(type, task));
        }
        public Dictionary<int, ITask> GetAllTasks()
        {
            return Storage.GetAllTasks();
        }
        public ITask GetTask(int id)
        {
            return Storage.GetTask(id);
        }
        public void DeleteTask(int id)
        {
            Storage.DeleteTask(id);
        }
        public void UpdateTask(int id, string newTask)
        {
            Storage.UpdateTask(id, newTask);
        }
        public void CompleteTask(int id)
        {
            Storage.CompleteTask(id);
        }

    }
}
