using MCC73MVC.Context;
using MCC73MVC.Repositories.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQL Server Databases
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<AccountRepositories>();
builder.Services.AddTransient<AccountRoleRepositories>();
builder.Services.AddTransient<DepartmentRepositories>();
builder.Services.AddTransient<DivisionRepositories>();
builder.Services.AddTransient<EmployeeRepositories>();
builder.Services.AddTransient<RoleRepositories>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
