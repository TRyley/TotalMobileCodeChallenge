using Microsoft.EntityFrameworkCore;
using Moq;
using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Adapters;

namespace TotalMobileChallenge.Tests.OutgoingTests
{
    [TestClass]
    public class GetEmployeeInfoDBAdapterTests
    {
        private GetEmployeeInfoDBAdapter _adapter;

        [TestInitialize]
        public void Setup()
        {
            var data = new List<Employee>
            {
                new Employee { Employee_ID = 1, FirstName = "firstname_1", SurName = "surname_1" },
                new Employee { Employee_ID = 2, FirstName = "firstname_2", SurName = "surname_2" },
                new Employee { Employee_ID = 3, FirstName = "firstname_3", SurName = "surname_3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CompanyContext>();
            mockContext.Setup(c => c.Employee).Returns(mockSet.Object);

            _adapter = new GetEmployeeInfoDBAdapter(mockContext.Object);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturn_ListOfEmployees()
        {
            
            var employees = _adapter.GetAllEmployees();

            Assert.AreEqual(3, employees.Count);
            Assert.AreEqual(1, employees[0].Employee_ID);
            Assert.AreEqual(2, employees[1].Employee_ID);
            Assert.AreEqual(3, employees[2].Employee_ID);

        }
    }
}
