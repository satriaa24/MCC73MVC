using MCC73MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MCC73MVC.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<Employee>().HasAlternateKey(e => e.Email);

        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Account)
            .WithOne(e => e.Employee)
            .HasForeignKey<Account>(a => a.NIK);

    }
}


