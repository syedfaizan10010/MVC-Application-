using formProject.DbContext;
using formProject.Factory;
using formProject.Factory.BookingTicketFactory;
using formProject.Factory.CarDetailsFactory;
using formProject.Factory.JobApplicationFactory;
using formProject.Factory.StudentFactory;
using formProject.Models.DomainObject;
using formProject.Models.DomainObject.BookingTicketDomain;
using formProject.Models.DomainObject.CarDetailsDomain;
using formProject.Models.DomainObject.JobApplicationDomain;
using formProject.Models.DomainObject.StudentDomain;
using formProject.Models.Repository;

namespace formProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            AddServices(builder.Services);

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
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeDataOperation>();
            services.AddScoped<IEmployeeFactory, EmployeeFactory>();
            services.AddScoped<IStudent,StudentDataOperation>();
            services.AddScoped<IStudentFactory,StudentFactory>();
            services.AddScoped<IJobApplication, JobApplicationDataOperation>();
            services.AddScoped<IJobAplicationFactory, JobApplicationFactory>();
            services.AddScoped<IBookingTicket,BookingTicketDataOperation>();
            services.AddScoped<IBookingTicketFactory,BookingTicketFactory>();
            services.AddScoped<ICarDetails, CarDetailsDataOperation>();
            services.AddScoped<ICarDetailsFactory,CarDetailsFactory>();
;           services.AddSingleton<DapperDbContext>();
        }
    }
}
