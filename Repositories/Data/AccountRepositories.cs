using MCC73MVC.Context;
using MCC73MVC.Models;
using MCC73MVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Account, string>
    {
        MyContext _context;
        private DbSet<Account> _account;
        private DbSet<Employee> _employee;
        private DbSet<Role> _role;
        private DbSet<Division> _division;
        private DbSet<Department> _department;

        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
            _account = context.Set<Account>();
            _employee = context.Set<Employee>();
            _role = context.Set<Role>();
            _division = context.Set<Division>();
            _department = context.Set<Department>();

        }

        //login
        public int Login(LoginVM login)
        {
            var result = _account.Join(_context.Employees, a => a.NIK, e => e.NIK, (a, e) =>
        new LoginVM
        {
            Email = e.Email,
            Password = a.Password
        }).SingleOrDefault(c => c.Email == login.Email);

            if (result == null)
            {
                return 0; // Email Tidak Terdaftar
            }
            return 1; // Email dan Password Benar
        }

        //register
        public int Register(RegisterVM reg)
        {
            {
                var result = 0;
                //employee
                Employee employee = new Employee()
                {
                    NIK = Convert.ToString("120"),
                    FirstName = reg.FirstName,
                    LastName = reg.LastName,
                    Gender = (Models.Gender)reg.Gender,
                    Email = reg.Email
                };
                _employee.Add(employee);
                result = _context.SaveChanges();

                //ACC
                Account account = new Account()
                {
                    Password = reg.Password
                };
                _account.Add(account);
                result = _context.SaveChanges();

                //role
                Role role = new Role()
                {
                    Name = reg.RoleName,
                };
                _role.Add(role);
                result = _context.SaveChanges();

                //Division
                Division division = new Division()
                {
                    Name = reg.DivisionName,

                };
                _division.Add(division);
                result = _context.SaveChanges();

                //Department
                Department department = new Department()
                {
                    Name = reg.DepartmentName,
                };
                _department.Add(department);
                result = _context.SaveChanges();


                return result;
            }
        }
    }
}
