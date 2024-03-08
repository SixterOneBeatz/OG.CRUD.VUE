using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OG.CRUD.VUE.Application.Application.Common.Behaviors;
using OG.CRUD.VUE.Application.Common.Behaviors;
using System.Reflection;

namespace OG.CRUD.VUE.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
                conf.AddOpenBehavior(typeof(UnhandledExceptionBehavior<,>));
            });

            return services;
        }
    }
}
