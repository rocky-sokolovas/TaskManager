using System;
using System.Collections.Generic;
using System.Text;
using TaskManager;

namespace TaskManagerTest
{
    [TestClass]
    public sealed class TaskManagerTest
    {
        [TestMethod]
        public void AddTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage,factory);
            tm.AddTask("Standard","Test");
        }
        [TestMethod]
        public void GetAllTasksTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "Test1");
            tm.AddTask("Standard", "Test2");
            tm.AddTask("Standard", "Test3");
            Assert.HasCount(3, tm.GetAllTasks());
        }
        [TestMethod]
        public void AddEmptyTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            var ex = Assert.Throws<Exception>(() => tm.AddTask("Standard", ""));
            Assert.Contains("Enter a Task Value.", ex.Message);
        }
        [TestMethod]
        public void GetTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "Test");
            ITask result = tm.GetTask(1);
            Assert.AreEqual("Test", result.Name);
        }
        [TestMethod]
        public void GetMultiTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "TestA");
            tm.AddTask("Standard", "TestB");
            ITask result = tm.GetTask(2);
            Assert.AreEqual("TestB", result.Name);
        }
        [TestMethod]
        public void DeleteTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "Test");
            tm.DeleteTask(1);
        }
        [TestMethod]
        public void DeleteEmptyTaskManagerTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            var ex = Assert.Throws<Exception>(() => tm.DeleteTask(1));
            Assert.Contains("There's no tasks available.", ex.Message);
        }
        [TestMethod]
        public void UpdateTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "Test");
            tm.UpdateTask(1, "Tester");
        }
        [TestMethod]
        public void CompleteTaskTest()
        {
            MemoryTaskStorage storage = new MemoryTaskStorage();
            TaskManager.TaskFactory factory = new TaskManager.TaskFactory();
            MainTaskManager tm = new MainTaskManager(storage, factory);
            tm.AddTask("Standard", "Test");
            tm.CompleteTask(1);
        }
    }
}
