using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TotalMobileChallenge.Server.Incoming.Ports;
using TotalMobileChallenge.Server.Models.PresentationModels;

namespace TotalMobileChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IGetData _employeeAdapter;
        public CompanyController(IGetData employeeAdapter)
        {
            _employeeAdapter = employeeAdapter;
        }

        [HttpGet]
        [Route("GetAllEmployeesInfo")]
        public List<EmployeeInfo> GetAllEmployees()
        {
            return _employeeAdapter.GetAllEmployeeData(); 
        }
    }
}
