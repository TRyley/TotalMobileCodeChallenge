
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalMobileChallenge.Server.Models.DatabaseModels
{
    public class EmployeeWorksShift
    {
        public int Employee_ID { get; set; }

        public int Shift_ID { get; set; }
    }
}
