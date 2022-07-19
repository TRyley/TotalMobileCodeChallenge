using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Server.Outgoing.Adapters
{
    public class GetEmployeeInfoDBAdapter: IGetEmployeeInfoDB
    {
        private CompanyContext _context;
        public GetEmployeeInfoDBAdapter(CompanyContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            var query = from b in _context.Employee
                        select b;

            return query.ToList();
        }
    }
}
