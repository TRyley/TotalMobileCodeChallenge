using TotalMobileChallenge.Server.Models.DatabaseModels;

namespace TotalMobileChallenge.Server.Outgoing.Ports
{
    public interface IGetShiftInfoDB
    {
        List<Shift> GetMultipleShifts(int[] ids);
    }
}
