using Crm.API;
using Crm.Application.AutoMapper;
using Crm.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tests.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public Mock<IStatusRepository> MockStatusRepository { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            MockStatusRepository = new Mock<IStatusRepository>();

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IStatusRepository));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());
                IMapper mapper = config.CreateMapper();
                services.AddSingleton(mapper);

                services.AddScoped(_ => MockStatusRepository.Object);
            });

            builder.UseTestServer();
        }
    }
}
