using TotalMobileChallenge.Server.Core.Interfaces;
using TotalMobileChallenge.Server.Models.PresentationModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Server.Core.Logic
{
    public class GetHoursWorkedLogic : IGetHoursWorkedLogic
    {
        private IGetEmployeeShiftDB _employeeShiftAdapter;
        private IGetShiftInfoDB _shiftInfoAdapter;
        public GetHoursWorkedLogic(IGetEmployeeShiftDB employeeShiftAdapter, IGetShiftInfoDB shiftAdapter)
        {
            _employeeShiftAdapter = employeeShiftAdapter;
            _shiftInfoAdapter = shiftAdapter;
        }
        public HoursWorkedInfo GetHoursWorkedForEmployee(int employeeId)
        {
            HoursWorkedInfo hoursWorkedInfo = new HoursWorkedInfo(employeeId);

            var employeeShifts = _employeeShiftAdapter.GetShiftIdsForEmployee(employeeId);
            var shifts = _shiftInfoAdapter.GetMultipleShifts(employeeShifts);

            foreach(var shift in shifts)
            {
                TimeSpan duration = shift.Shift_End - shift.Shift_Start;
                if (!hoursWorkedInfo.MonthlyHoursWorked.ContainsKey(shift.Shift_Start.ToString("MMM")))
                {
                    hoursWorkedInfo.MonthlyHoursWorked.Add(shift.Shift_Start.ToString("MMM"), 0);
                }

                hoursWorkedInfo.MonthlyHoursWorked[shift.Shift_Start.ToString("MMM")] += duration.TotalHours;
                hoursWorkedInfo.TotalHoursWorked += duration.TotalHours;
            }

            return hoursWorkedInfo;
        }
    }
}
