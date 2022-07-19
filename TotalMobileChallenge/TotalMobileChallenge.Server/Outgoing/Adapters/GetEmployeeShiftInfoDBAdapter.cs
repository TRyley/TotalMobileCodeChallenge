using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Server.Outgoing.Adapters
{
    public class GetEmployeeShiftInfoDBAdapter: IGetEmployeeShiftDB
    {
        private CompanyContext _context;
        public GetEmployeeShiftInfoDBAdapter(CompanyContext context)
        {
            _context = context;
        }

        public int[] GetShiftIdsForEmployee(int Id)
        {
            var query = from b in _context.Employee_Works_Shift
                        where b.Employee_ID == Id
                        select b.Shift_ID;

            return query.ToArray();
        }
    }
}
