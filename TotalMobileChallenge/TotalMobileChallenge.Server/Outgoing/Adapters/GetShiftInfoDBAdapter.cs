using TotalMobileChallenge.Server.Context;
using TotalMobileChallenge.Server.Models.DatabaseModels;
using TotalMobileChallenge.Server.Outgoing.Ports;

namespace TotalMobileChallenge.Server.Outgoing.Adapters
{
    public class GetShiftInfoDBAdapter: IGetShiftInfoDB
    {
        private CompanyContext _context;
        public GetShiftInfoDBAdapter(CompanyContext context)
        {
            _context = context;
        }

        public List<Shift> GetMultipleShifts(int[] ids)
        {
            var query = from b in _context.Shifts
                        where ids.Contains(b.Shift_ID)
                        select b;

            return query.ToList();
        }
    }
}
