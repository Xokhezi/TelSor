using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AccountingRecord> AccountingRecords { get; set; }
        public DbSet<AccountingPrinterRental> AccountingPrinterRentals { get; set; }
        public DbSet<AccountingPrinterPrint> AccountingPrinterPrints { get; set; }
        public DbSet<PrinterMaster> PrinterMasters { get; set; }
        public DbSet<ManagersMasterData> ManagersMasterDatas { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<NumberMasterData> NumberMasterDatas { get; set; }
        public DbSet<PrinterRecord> PrinterRecords { get; set; }
        public DbSet<PrinterRecordPrint> PrinterRecordPrints { get; set; }

        public DbSet<Record> Records { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}