using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Bogus.DataSets;
using Bogus;
using Crm.API;
using Crm.API.Controllers;
using Crm.Application.AutoMapper;
using Crm.Application.UseCases.StatusUseCases;
using Crm.Application.ViewModel;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Tests.IntegrationTests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

public class StatusIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    private const string BaseUrl = "api/status";

    public StatusIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Status_Execute_ShouldCreateNewStatus()
    {
        // Arrange
        var newStatus = new StatusVM
        {
            Name = new Faker().Random.String2(25),
            IsActivated = true,
            IsFinisher = false
        };

        // Act
        var response = await _client.PostAsJsonAsync($"{BaseUrl}/create", newStatus);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public void Status_GetAll_ShouldReturnAllStatuses()
    {
        // Arrange
        var statusRepositoryMock = new Mock<IStatusRepository>();
        var mapperMock = new Mock<IMapper>();

        var statusList = new List<Status>
            {
                new Status { Id = 1, Name = "Status 1", IsActivated = true, IsFinisher = false },
                new Status { Id = 2, Name = "Status 2", IsActivated = false, IsFinisher = true }
            };

        statusRepositoryMock.Setup(repo => repo.GetAll()).Returns(statusList);

        var statusController = new StatusController(statusRepositoryMock.Object);

        // Act
        var getResult = statusController.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(getResult);
        Assert.Equal(200, getResult.StatusCode);

        var returnedStatusList = getResult.Value as List<Status>;
        Assert.NotNull(returnedStatusList);
        Assert.Equal(statusList.Count, returnedStatusList.Count());
    }
}
