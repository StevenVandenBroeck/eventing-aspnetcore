using System;
using System.Linq;
using Eventing.Handling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Eventing.UnitTests.Startup
{
    public class StartupExtensionsTests
    {
        [Fact]
        void ValidOptionsAreRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddEventing(opt => opt.RegisterExceptionHandler<TestExceptionHandler>());

            var registrations = services.Where(sd => sd.ServiceType == typeof(IConfigureOptions<EventingOptions>))
                                        .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }

        [Fact]
        void NullOptionsAreRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddEventing();

            var registrations = services.Where(sd => sd.ServiceType == typeof(IConfigureOptions<EventingOptions>))
                                        .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }

        [Fact]
        void ExceptionHandlerIsRegisteredAsScoped()
        {
            var services = new ServiceCollection();
            services.AddEventing(opt => opt.RegisterExceptionHandler<TestExceptionHandler>());

            var registrations = services.Where(sd => sd.ServiceType == typeof(IEventingExceptionHandler) &&
                                                     sd.ImplementationType == typeof(TestExceptionHandler))
                                        .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Scoped, registrations[0].Lifetime);
        }

        [Fact]
        void DefaultExceptionHandlerIsRegisteredAsScoped()
        {
            var services = new ServiceCollection();
            services.AddEventing();

            var registrations = services.Where(sd => sd.ServiceType == typeof(IEventingExceptionHandler) &&
                                                     sd.ImplementationType == typeof(DefaultEventingExceptionHandler))
                                        .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Scoped, registrations[0].Lifetime);
        }
    }
}
