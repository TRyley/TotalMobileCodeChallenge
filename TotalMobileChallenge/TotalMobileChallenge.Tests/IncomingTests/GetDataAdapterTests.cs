using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalMobileChallenge.Server.Core.Interfaces;
using TotalMobileChallenge.Server.Incoming.Adapters;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Models.PresentationModels;

namespace TotalMobileChallenge.Tests.IncomingTests
{
    [TestClass]
    public class GetDataAdapterTests
    {
        private GetDataAdapter _adapter;
        private List<Employee> testEmployees;
        private HoursWorkedInfo testHours;

        Mock<IGetHoursWorkedLogic> hoursMock;

        [TestInitialize]
        public void Setup()
        {
            testEmployees = new List<Employee>
            {
                new Employee { Employee_ID = 0, FirstName = "firstname 0", SurName = "surname 0" },
                new Employee { Employee_ID = 1, FirstName = "firstname 1", SurName = "surname 1" },
                new Employee { Employee_ID = 2, FirstName = "firstname 2", SurName = "surname 2" },
            };

            testHours = new HoursWorkedInfo(1)
            {
                TotalHoursWorked = 25,
                MonthlyHoursWorked = new Dictionary<string, double>
                {
                    { "Jan", 10 },
                    {"Feb", 4.75 },
                    {"Mar", 6.25 },
                    {"Apr", 4 }
                }
            };
            Mock<IGetEmployeesLogic> employeesMock = new Mock<IGetEmployeesLogic>();
            employeesMock.Setup(x => x.GetAllEmployees()).Returns(testEmployees);

            hoursMock = new Mock<IGetHoursWorkedLogic>();
            hoursMock.Setup(x => x.GetHoursWorkedForEmployee(It.IsAny<int>())).Returns(testHours);

            _adapter = new GetDataAdapter(employeesMock.Object, hoursMock.Object);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnAListOfEmployees()
        {
            var actual = _adapter.GetAllEmployeeData();
            Assert.AreEqual(testEmployees.Count(), actual.Count());
        }

        [TestMethod]
        public void GetAllEmployees_ShouldContainTheCorrectInformation()
        {
            var actual = _adapter.GetAllEmployeeData();
            for (var i = 0; i < 3; i++)
            {
                Assert.AreEqual(testEmployees[i].Employee_ID, actual[i].Id);
                Assert.AreEqual($"{testEmployees[i].FirstName} {testEmployees[i].SurName}", actual[i].Name);
            }
        }

        [TestMethod]
        public void GetAllEmployees_GetsHoursWorked()
        {
            var actual = _adapter.GetAllEmployeeData();
            hoursMock.Verify(x => x.GetHoursWorkedForEmployee(It.IsAny<int>()));
        }
    }
}
