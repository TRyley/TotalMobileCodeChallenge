using TotalMobileChallenge.Server.Models.DatabaseModels;

namespace TotalMobileChallenge.Server.Core.Interfaces
{
    public interface IGetEmployeesLogic
    {
        List<Employee> GetAllEmployees();
    }
}
