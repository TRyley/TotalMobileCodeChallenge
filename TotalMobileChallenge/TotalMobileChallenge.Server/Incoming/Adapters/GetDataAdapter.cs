using TotalMobileChallenge.Server.Core.Interfaces;
using TotalMobileChallenge.Server.Incoming.Ports;
using TotalMobileChallenge.Server.Models.PresentationModels;

namespace TotalMobileChallenge.Server.Incoming.Adapters
{
    public class GetDataAdapter: IGetData
    {
        private IGetEmployeesLogic _employeesLogic;
        private IGetHoursWorkedLogic _getHoursWorkedLogic;
        public GetDataAdapter(IGetEmployeesLogic getEmployeesLogic, IGetHoursWorkedLogic getHoursWorkedLogic)
        {
            _employeesLogic = getEmployeesLogic;
            _getHoursWorkedLogic = getHoursWorkedLogic;
        }
        public List<EmployeeInfo> GetAllEmployeeData()
        {
            List<EmployeeInfo> employees = new List<EmployeeInfo>();

            var dbEmployees = _employeesLogic.GetAllEmployees();

            foreach(var employee in dbEmployees)
            {
                var newInfo = new EmployeeInfo
                {
                    Id = employee.Employee_ID,
                    Name = $"{employee.FirstName} {employee.SurName}",
                    HoursWorked = _getHoursWorkedLogic.GetHoursWorkedForEmployee(employee.Employee_ID)
                };

                employees.Add(newInfo);
            }

            return employees;
        }
    }
}
