using TaskManager;

namespace TaskManagerTest
{
    [TestClass]
    public sealed class TaskTest
    {
        [TestMethod]
        public void AddNewTaskString()
        {
            StandardTask test = new StandardTask("Test Task");
            Assert.AreEqual("Test Task", test.Name);
        }
        [TestMethod]
        public void CompleteTaskTest()
        {
            StandardTask test = new StandardTask("Test Task");
            Assert.IsFalse(test.Completed);
            test.CompleteTask();
            Assert.IsTrue(test.Completed);
            test.CompleteTask();
            Assert.IsFalse(test.Completed);
        }
        [TestMethod]
        public void UpdateTaskNameTest()
        {
            StandardTask test = new StandardTask("Initial Name");
            Assert.AreEqual("Initial Name", test.Name);
            test.UpdateTask("Updated Name");
            Assert.AreEqual("Updated Name", test.Name);
        }
        [TestMethod]
        public void AddEmptyTask()
        {
            var ex = Assert.Throws<Exception>(() => new StandardTask(""));
            Assert.Contains("Enter a Task Value.", ex.Message);
        }
        [TestMethod]
        public void UpdateEmptyTaskNameTest()
        {
            StandardTask test = new StandardTask("Initial Name");
            Assert.AreEqual("Initial Name", test.Name);
            var ex=Assert.Throws<Exception>(()=>test.UpdateTask(""));
            Assert.Contains("Enter a Task Value.",ex.Message);
        }
    }

}
