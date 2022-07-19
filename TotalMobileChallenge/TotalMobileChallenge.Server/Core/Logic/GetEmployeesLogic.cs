using TotalMobileChallenge.Server.Core.Interfaces;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Server.Core.Logic
{
    public class GetEmployeesLogic : IGetEmployeesLogic
    {
        private IGetEmployeeInfoDB _adapter;
        public GetEmployeesLogic(IGetEmployeeInfoDB employeeDBAdapter)
        {
            _adapter = employeeDBAdapter;
        }
        public List<Employee> GetAllEmployees()
        {
            return _adapter.GetAllEmployees();
        }
    }
}
