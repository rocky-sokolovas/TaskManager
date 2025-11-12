// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using TaskManager;
MemoryTaskStorage storage = new MemoryTaskStorage();
TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
MainTaskManager tm = new MainTaskManager(storage, factory);
tm.AddTask("Standard", "Test1");
tm.AddTask("Standard", "Test2");
tm.AddTask("Standard", "Test3");
ITask taskToComplete = tm.GetTask(2);
taskToComplete.CompleteTask();
List<string> actions = ["add", "update", "complete", "delete", "exit"];

while (true) 
{
    Console.Clear();
    Dictionary<int, ITask>  Tasks = tm.GetAllTasks();
    Console.Write("To-Do: \n\n");
    foreach(var item in Tasks)
    {
        Console.Write(item.Key);
        Console.Write(": ");
        Console.Write(item.Value.Name);
        Console.Write(" ");
        if (item.Value.Completed)
        {
            Console.WriteLine("[✓]");
        }
        else
        {
            Console.WriteLine("[ ]");
        }
    }
    Console.Write("\n\n\n");
    Console.WriteLine("Possible Commands:\n ");
    foreach(string action in actions)
    {
        Console.Write($"{action}  ");
    }
    Console.WriteLine("\n\nEnter a command:");
    string chosenAction = Console.ReadLine();
    if (chosenAction.Length==0)
    {
        Console.WriteLine("No command given, try again.");
        Console.ReadKey();
    }
    else if (chosenAction.ToLower()=="exit")
    {
        break;
    }
    else 
    {
        string[] actionStrings = chosenAction.Split(" ");
        if (actionStrings[0].ToLower()=="add")
        {
            tm.AddTask("Standard", chosenAction.Substring(4));
        }
        if (actionStrings[0].ToLower() == "delete")
        {
            tm.DeleteTask(Int32.Parse(actionStrings[1]));
        }
        if (actionStrings[0].ToLower() == "complete")
        {
            tm.CompleteTask(Int32.Parse(actionStrings[1]));
        }
        if (actionStrings[0].ToLower() == "update")
        {
            int taskID = Int32.Parse(actionStrings[1]);
            var newTask = string.Join(" ", actionStrings.Skip(2));
            tm.UpdateTask(taskID,newTask);
        }
    }
}