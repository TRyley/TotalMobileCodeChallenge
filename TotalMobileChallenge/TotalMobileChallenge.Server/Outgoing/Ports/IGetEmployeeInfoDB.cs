using TotalMobileChallenge.Server.Models.DatabaseModels;

namespace TotalMobileChallenge.Server.Outgoing.Ports
{
    public interface IGetEmployeeInfoDB
    {
        List<Employee> GetAllEmployees();
    }
}
