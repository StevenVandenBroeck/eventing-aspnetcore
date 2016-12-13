using System;
using System.Collections.Generic;
using Eventing.Handling;
using Microsoft.Extensions.DependencyInjection;

namespace Eventing
{
    public static class EventPublisherStartupExtensions
    {
        public static IServiceCollection AddEventing(this IServiceCollection services, Action<EventingOptions> setupAction = null)
        {
            //services.AddScoped<IEventPublisher, EventPublisher>();

            //services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
            //services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

            if ( setupAction == null ) setupAction = opt => opt.RegisterExceptionHandler<DefaultEventingExceptionHandler>();

            ConfigureOptions(services, setupAction);

            return services;
        }

        private static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }

        private static void ConfigureOptions(IServiceCollection services, Action<EventingOptions> setupAction)
        {
            services.Configure(setupAction);
            var options = new EventingOptions();
            setupAction.Invoke(options);

            var handlerType = options.ExceptionHandlerType ?? typeof(DefaultEventingExceptionHandler);
            services.AddScoped(typeof(IEventingExceptionHandler), handlerType);
        }
    }
}
