using Invoice_Management_Api.Services;

namespace Invoice_Management_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionStr = builder.Configuration.GetConnectionString("DefaulConnection");

            builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddScoped<ICashierService, CashierService>();

            builder.Services.AddScoped<IBranchService, BranchService>();

            //builder.Services.AddScoped<ICityService, CityService>();

            //builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionStr));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
