namespace TotalMobileChallenge.Server.Models.PresentationModels
{
    public class HoursWorkedInfo
    {
        public HoursWorkedInfo(int employeeId)
        {
            EmployeeId = employeeId;
        }
        public int EmployeeId { get; private set; }
        public Dictionary<string, double> MonthlyHoursWorked { get; set; } = new Dictionary<string, double>();
        public double TotalHoursWorked { get; set; } = 0;
    }
}
