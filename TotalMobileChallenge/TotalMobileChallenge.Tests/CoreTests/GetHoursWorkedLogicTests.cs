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
    public class GetHoursWorkedLogicTests
    {
        private GetHoursWorkedLogic _getHoursWorkedLogic;

        [TestInitialize]
        public void Setup()
        {
            int[] testEmployeeShiftInfo = { 1,4,5 };
            List<Shift> testShiftInfo = new List<Shift> {
                new Shift { Shift_ID = 1, Shift_Start = new DateTime(2022, 4, 10, 9, 0, 0), Shift_End = new DateTime(2022, 4, 10, 15, 30, 0) , Shift_Name = "test shift 1"},
                new Shift { Shift_ID = 4, Shift_Start = new DateTime(2022, 4, 11, 9, 0, 0), Shift_End = new DateTime(2022, 4, 11, 16, 0, 0) , Shift_Name = "test shift 2"},
                new Shift { Shift_ID = 5, Shift_Start = new DateTime(2022, 5, 10, 9, 0, 0), Shift_End = new DateTime(2022, 5, 10, 12, 45, 0) , Shift_Name = "test shift 3"}
            };

            Mock<IGetEmployeeShiftDB> employeeShiftMock = new Mock<IGetEmployeeShiftDB>();
            Mock<IGetShiftInfoDB> shiftMock = new Mock<IGetShiftInfoDB>();

            employeeShiftMock.Setup(x => x.GetShiftIdsForEmployee(It.IsAny<int>())).Returns(testEmployeeShiftInfo);
            shiftMock.Setup(x => x.GetMultipleShifts(It.IsAny<int[]>())).Returns(testShiftInfo);

            _getHoursWorkedLogic = new GetHoursWorkedLogic(employeeShiftMock.Object, shiftMock.Object);
        }

        [TestMethod]
        public void GetHoursWorkedForEmployee_ShouldCalculateTotalHoursWorked()
        {
            var actual = _getHoursWorkedLogic.GetHoursWorkedForEmployee(1);

            Assert.AreEqual(17.25, actual.TotalHoursWorked);
        }

        [TestMethod]
        public void GetHoursWorkedForEmployee_ShouldCalculateHoursWorkedForEachMonth()
        {
            var actual = _getHoursWorkedLogic.GetHoursWorkedForEmployee(1);

            Assert.AreEqual(3.75, actual.MonthlyHoursWorked["May"]);
            Assert.AreEqual(13.5, actual.MonthlyHoursWorked["Apr"]);
        }
    }
}
