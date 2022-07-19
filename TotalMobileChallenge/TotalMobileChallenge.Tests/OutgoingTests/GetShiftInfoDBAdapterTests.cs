using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Adapters;

namespace TotalMobileChallenge.Tests.OutgoingTests
{
    [TestClass]
    public class GetShiftInfoDBAdapterTests
    {
        private GetShiftInfoDBAdapter _adapter;

        [TestInitialize]
        public void Setup()
        {
            var data = new List<Shift>
            {
                new Shift { Shift_ID = 1, Shift_Name = "shiftName", Shift_Start = DateTime.MinValue, Shift_End = DateTime.MaxValue },
                new Shift { Shift_ID = 2, Shift_Name = "shiftName", Shift_Start = DateTime.MinValue, Shift_End = DateTime.MaxValue },
                new Shift { Shift_ID = 3, Shift_Name = "shiftName", Shift_Start = DateTime.MinValue, Shift_End = DateTime.MaxValue },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Shift>>();
            mockSet.As<IQueryable<Shift>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shift>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shift>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shift>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<CompanyContext>();
            mockContext.Setup(c => c.Shifts).Returns(mockSet.Object);

            _adapter = new GetShiftInfoDBAdapter(mockContext.Object);
        }

        [TestMethod]public void GetMultipleShifts_ShouldReturn_CorrectShifts()
        {
            int[] ids = { 1, 3 };
            var shifts = _adapter.GetMultipleShifts(ids);

            Assert.AreEqual(2, shifts.Count());
            Assert.AreEqual(1, shifts[0].Shift_ID);
            Assert.AreEqual(3, shifts[1].Shift_ID);
        }
    }
}
