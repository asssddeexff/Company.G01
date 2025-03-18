using Company.G01.DAL.Data.Contexts;
using Company.G01.PL.Mapping;
using Company.G01.PL.Services;
using Company.G02.BLL.Interfices;
using Company.G02.BLL.Repositres;
using Microsoft.EntityFrameworkCore;

namespace Company.G01.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//Register Built-In Mvc Services
            builder.Services.AddScoped<IDepartmentRepositry, DepartmentRepositry>();//Allow DI For DepartmentRepositry
            builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();//Allow DI For EmployeeRepositry
            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {


                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });//Allow DI For CompanyDbContext

            //builder.Services.AddAutoMapper(typeof(EmployeeProfile));
            builder.Services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));

            //Life Time
            //builder.Services.AddScoped();//Create Object Life Time Per Request -Unreachable Object
            //builder.Services.AddTransient();//Create Object Life Time Per Operation
            //builder.Services.AddSingleton();//Create Object Life Time Per App

            builder.Services.AddScoped<IScopedSerivece,ScopedServicecs>();//Per Request
            builder.Services.AddTransient<ITransentService, TransentService>();//Per Operation
            builder.Services.AddSingleton<ISengletonService,SengletonSerivce>();//Per App
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
        }
    }
}
