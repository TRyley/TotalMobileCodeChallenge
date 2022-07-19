using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalMobileChallenge.Server.Core.Logic;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Tests.CoreTests
{
    [TestClass]
    public class GetEmployeesLogicTests
    {
        private GetEmployeesLogic _employeesLogic;
        [TestInitialize]
        public void Setup()
        {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee { Employee_ID = 1, FirstName = "firstname", SurName = "surname" },
                new Employee { Employee_ID = 2, FirstName = "firstname", SurName = "surname" },
                new Employee { Employee_ID = 3, FirstName = "firstname", SurName = "surname" },
            };

            Mock<IGetEmployeeInfoDB> adapterMock = new Mock<IGetEmployeeInfoDB>();
            adapterMock.Setup(x => x.GetAllEmployees()).Returns(employeeList);

            _employeesLogic = new GetEmployeesLogic(adapterMock.Object);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnAListOfEmployees()
        {
            var actual = _employeesLogic.GetAllEmployees();

            Assert.AreEqual(3, actual.Count());
        }
    }
}
