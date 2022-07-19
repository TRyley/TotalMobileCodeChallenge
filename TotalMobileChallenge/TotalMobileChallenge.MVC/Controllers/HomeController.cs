using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using TotalMobileChallenge.Client.Models.PresentationModels;
using TotalMobileChallenge.MVC.Models;

namespace TotalMobileChallenge.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseUrl = "https://localhost:7046/api/Company/";
        private readonly ILogger<HomeController> _logger;
        private EmployeeViewModel _employeeModel = new EmployeeViewModel();
        private HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseUrl);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult Index()
        {
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = _httpClient.GetAsync("GetAllEmployeesInfo").GetAwaiter().GetResult();
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list
                _employeeModel.employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(EmpResponse);
            }

            return View(_employeeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}