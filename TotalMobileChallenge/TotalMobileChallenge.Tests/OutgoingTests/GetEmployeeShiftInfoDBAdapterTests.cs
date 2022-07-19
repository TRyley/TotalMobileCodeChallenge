using Microsoft.EntityFrameworkCore;
using Moq;
using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Adapters;

namespace TotalMobileChallenge.Tests.OutgoingTests
{
    [TestClass]
    public class GetEmployeeShiftInfoDBAdapterTests
    {
        private GetEmployeeShiftInfoDBAdapter _adapter;

        [TestInitialize]
        public void Setup()
        {
            var data = new List<EmployeeWorksShift>
             {
                new EmployeeWorksShift { Shift_ID = 1, Employee_ID = 1 },
                new EmployeeWorksShift { Shift_ID = 2, Employee_ID = 2 },
                new EmployeeWorksShift { Shift_ID = 3, Employee_ID = 1 },
                new EmployeeWorksShift { Shift_ID = 1, Employee_ID = 2 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<EmployeeWorksShift>>();
            mockSet.As<IQueryable<EmployeeWorksShift>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<EmployeeWorksShift>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<EmployeeWorksShift>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<EmployeeWorksShift>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CompanyContext>();
            mockContext.Setup(c => c.Employee_Works_Shift).Returns(mockSet.Object);

            _adapter = new GetEmployeeShiftInfoDBAdapter(mockContext.Object);
        }

        [TestMethod]
        public void GetShiftIdsForEmployee_ShouldGetCorrectListOfShifts()
        {
            var shifts = _adapter.GetShiftIdsForEmployee(1);

            Assert.AreEqual(2, shifts.Count());
            Assert.AreEqual(1, shifts[0]);
            Assert.AreEqual(3, shifts[1]);
        }
    }
}
