
using BLL.EmployeeService;
using BLL.StoreService;
using BLL.TitleService;
using DAL;
using DAL.EmployeeRepo;
using DAL.StoreRepo;
using DAL.TitleRepo;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BasicCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PubsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IStoreRepo, StoreRepo>();
            builder.Services.AddScoped<IStoreService, StoreService>();
            builder.Services.AddScoped<ITitleRepo, TitleRepo>();
            builder.Services.AddScoped<ITitleService, TitleService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
