using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    public class TaskFactory
    {
        public ITask CreateTask(string TaskType, string TaskDefinition)
        {
            ITask newTask;
            if (TaskType == "standard")
            {
                try
                {
                    newTask = new StandardTask(TaskDefinition);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    newTask = new StandardTask(TaskDefinition);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return newTask;
        }
    }
}
