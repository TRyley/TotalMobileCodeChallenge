using TotalMobileChallenge.Server.Models.DatabaseModels;

namespace TotalMobileChallenge.Server.Outgoing.Ports
{
    public interface IGetEmployeeShiftDB
    {
        int[] GetShiftIdsForEmployee(int id);
    }
}
