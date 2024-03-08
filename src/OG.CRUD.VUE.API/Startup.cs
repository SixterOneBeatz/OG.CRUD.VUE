using OG.CRUD.VUE.API.Middlewares;
using static OG.CRUD.VUE.Application.ApplicationServiceRegistration;
using static OG.CRUD.VUE.Infrastructure.InfrastructureServiceRegistration;

namespace OG.CRUD.VUE.API
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApplication();
            services.AddInfrastructure(configuration);

            services.AddCors(options =>
            {
                var client = configuration["clientUrl"];
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.MapControllers();

            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}
