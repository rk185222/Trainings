using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee()
            {
                Id = 1,
                Name = "Emp1",
                Email = "Emp1@gmail.com",
                Department = Dept.HR
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
