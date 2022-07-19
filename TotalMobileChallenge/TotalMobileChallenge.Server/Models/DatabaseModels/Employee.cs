
using System.ComponentModel.DataAnnotations;

namespace TotalMobileChallenge.Server.Models.DatabaseModels
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
