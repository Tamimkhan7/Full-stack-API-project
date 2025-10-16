using Microsoft.EntityFrameworkCore;
using ReactAPICURDBackend.Models;

namespace ReactAPICURDBackend.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> students { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.; initial catalog=ibs; User Id=sa; password123;  TrustServerCertificate = True;");
        //}

    }

}
