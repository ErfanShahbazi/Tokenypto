using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenypto.Api.FunctionalTests.Infrastructure
{
    public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestsWebAppFactory>
    {
        protected readonly HttpClient HttpClient;

        protected BaseFunctionalTest(FunctionalTestsWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();
        }
    }
}
