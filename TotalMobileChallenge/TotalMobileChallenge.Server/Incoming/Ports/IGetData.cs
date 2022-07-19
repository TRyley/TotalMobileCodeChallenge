using TotalMobileChallenge.Server.Models.PresentationModels;

namespace TotalMobileChallenge.Server.Incoming.Ports
{
    public interface IGetData
    {
        List<EmployeeInfo> GetAllEmployeeData();
    }
}
