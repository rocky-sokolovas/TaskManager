using System.ComponentModel;

namespace TaskManager
{
    public interface ITask
    {
        string Name { get; }
        bool Completed { get; }

        void CompleteTask();
        void UpdateTask(string name);
    }
    public class StandardTask : ITask
    {
        public StandardTask(string name)
        {
            Name = name;
        }
        private string _name = string.Empty;
        public string Name {  
            get =>_name;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Enter a Task Value.");
                }
                else
                {
                    _name = value;
                }
            }
        }
        private bool _completed = false;
        public bool Completed
        {
            get => _completed;
            set => _completed = value;
        }

        public void CompleteTask()
        {
            Completed = !this.Completed;
        }
        public void UpdateTask(string name)
        {
            Name = name;
        }
    }
}