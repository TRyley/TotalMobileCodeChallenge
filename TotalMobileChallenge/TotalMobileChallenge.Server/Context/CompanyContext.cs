using Microsoft.EntityFrameworkCore;
using TotalMobileChallenge.Server.Models.DatabaseModels;

namespace TotalMobileChallenge.Server.Context
{
    public class CompanyContext
        : DbContext
    {
        public CompanyContext()
            : base()
        {

        }
        public CompanyContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<EmployeeWorksShift> Employee_Works_Shift { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeWorksShift>().HasKey(ews => new { ews.Employee_ID, ews.Shift_ID });
        }
    }
}

