
using System.ComponentModel.DataAnnotations;

namespace TotalMobileChallenge.Server.Models.DatabaseModels
{
    public class Shift
    {
        [Key]
        public int Shift_ID { get; set; }

        public DateTime Shift_Start { get; set; }
        public DateTime Shift_End { get; set; }
        public string Shift_Name { get; set; }
    }
}
