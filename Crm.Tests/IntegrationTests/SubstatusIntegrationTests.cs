using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using Crm.API;
using Crm.API.Controllers;
using Crm.Application.AutoMapper;
using Crm.Application.UseCases.StatusUseCases;
using Crm.Application.ViewModel;
using Crm.Application.ViewModel.Motivo;
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

public class SubstatusIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    private const string BaseUrl = "api/substatus";

    public SubstatusIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Substatus_Execute_ShouldCreateNewSubstatus()
    {
        // Arrange
        var newSubstatus = new SubstatusVM
        {
            Name = new Faker().Random.String2(25),
            IsActivated = true
        };

        // Act
        var response = await _client.PostAsJsonAsync($"{BaseUrl}/create", newSubstatus);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Substatus_GetAll_ShouldReturnAllSubstatuses()
    {
        // Arrange
        var substatusRepositoryMock = new Mock<ISubstatusRepository>();
        var mapperMock = new Mock<IMapper>();

        var substatusList = new List<Substatus>
        {
            new Substatus { Id = 1, Name = "Substatus 1", IsActivated = true },
            new Substatus { Id = 2, Name = "Substatus 2", IsActivated = false }
        };

        substatusRepositoryMock.Setup(repo => repo.GetAll()).Returns(substatusList);

        var substatusController = new SubstatusController(substatusRepositoryMock.Object);

        // Act
        var getResult = substatusController.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(getResult);
        Assert.Equal(200, getResult.StatusCode);

        var returnedSubstatusList = getResult.Value as List<Substatus>;
        Assert.NotNull(returnedSubstatusList);
        Assert.Equal(substatusList.Count, returnedSubstatusList.Count);
    }
}
