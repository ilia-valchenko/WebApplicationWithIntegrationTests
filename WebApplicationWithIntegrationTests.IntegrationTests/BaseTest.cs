using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplicationWithIntegrationTests.Repositories.Interfaces;

namespace WebApplicationWithIntegrationTests.IntegrationTests
{
    public class BaseTest
    {
        private TestServer testServer;

        protected MockRepository mockRepository;
        protected Mock<IPersonRepository> mockPersonRepository;

        [TestInitialize]
        public void RebuildTestServer()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockPersonRepository = this.mockRepository.Create<IPersonRepository>();

            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddScoped(_ => this.mockPersonRepository.Object);
                });

            this.testServer = new TestServer(builder);
        }

        //[TestCleanup]
        //public virtual void FinalizeTest()
        //{
        //    this.mockRepository.VerifyAll();
        //}

        protected HttpClient CreateClient()
        {
            var appConfig = this.GetAppConfig();

            var client = this.testServer.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appConfig["Token"]);
            client.DefaultRequestHeaders.Add("Custom-Auth-Header", new[] { "testValue" });

            return client;
        }

        private IConfiguration GetAppConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}