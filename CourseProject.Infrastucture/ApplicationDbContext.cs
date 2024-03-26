using CourseProject.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastucture;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Team>  Teams { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Courseproject.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Address>().HasKey(e => e.Id);
        builder.Entity<Employee>().HasKey(e => e.Id);
        builder.Entity<Job>().HasKey(e => e.Id);
        builder.Entity<Team>().HasKey(e => e.Id);

        builder.Entity<Employee>().HasOne(e => e.Address);
        builder.Entity<Employee>().HasOne(e => e.Job);

        builder.Entity<Team>().HasMany(e => e.Employees).WithMany(e => e.Teams);

        base.OnModelCreating(builder);
    }
}
