using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetAllSuccesTest()
        {
            // Arrange
            Department department1 = new Department() { Name = "IT", Department_Head = 101 };
            Department department2 = new Department() { Name = "HR", Department_Head = 102 };
            repository.Add(department1);
            repository.Add(department2);

            // Action
            var result = repository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); 
        }

        [TestCase(1, "Hr", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}