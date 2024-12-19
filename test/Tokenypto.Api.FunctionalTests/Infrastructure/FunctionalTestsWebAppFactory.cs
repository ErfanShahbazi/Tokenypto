using Carter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenypto.Api.Configurations.ApiVersioningConfiguration;
using Tokenypto.Api.Configurations.HttpClientConfiguration;
using Tokenypto.Api.Configurations.ServicesConfiguration;
using Tokenypto.Api.Services.Crypto;

namespace Tokenypto.Api.FunctionalTests.Infrastructure
{
    public class FunctionalTestsWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {

                services.AddHttpClientConfiguration();
                services.AddServicesConfiguration();
                services.AddCarter();
                services.AddApiVersioningConfiguration();

            });
        }

        public new Task DisposeAsync()
        {
            
            return default;
        }

        public Task InitializeAsync()
        {
            return default;
        }
    }
}
