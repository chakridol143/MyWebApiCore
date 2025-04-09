
using Microsoft.EntityFrameworkCore;
using MvcDHProject.Models;
using MyWebApiCoreService.Models;

namespace MyWebApiCoreService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICustomerDal, CustomerXmlDal>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllerRoute(
                name:"default",
                pattern:"{Controller=Home}/{Action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
