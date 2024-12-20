namespace Tokenypto.FunctionalTests.Infrastructure;

public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>
{
    protected readonly HttpClient Client;

    protected BaseFunctionalTest(FunctionalTestWebAppFactory webAppFactory)
    {
        Client = webAppFactory.CreateClient();
    }
}
