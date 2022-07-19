using TotalMobileChallenge.Server.Models.PresentationModels;

namespace TotalMobileChallenge.Server.Core.Interfaces
{
    public interface IGetHoursWorkedLogic
    {
        HoursWorkedInfo GetHoursWorkedForEmployee(int employeeId);
    }
}
