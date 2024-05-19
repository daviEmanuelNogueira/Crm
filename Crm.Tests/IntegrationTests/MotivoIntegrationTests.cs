using System.Drawing;
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

public class MotivoIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    private const string BaseUrl = "api/motivo";

    public MotivoIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Motivo_Execute_ShouldCreateNewMotivo()
    {
        // Arrange
        var newMotivo = new MotivoVM
        {
            Name = new Faker().Random.String2(25),
            IsActivated = true
        };

        // Act
        var response = await _client.PostAsJsonAsync($"{BaseUrl}/create", newMotivo);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Motivo_GetAll_ShouldReturnAllMotivos()
    {
        // Arrange
        var motivoRepositoryMock = new Mock<IMotivoRepository>();
        var mapperMock = new Mock<IMapper>();

        var motivoList = new List<Motivo>
        {
            new Motivo { Id = 1, Name = "Motivo 1", IsActivated = true },
            new Motivo { Id = 2, Name = "Motivo 2", IsActivated = false }
        };

        motivoRepositoryMock.Setup(repo => repo.GetAll()).Returns(motivoList);

        var motivoController = new MotivoController(motivoRepositoryMock.Object);

        // Act
        var getResult = motivoController.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(getResult);
        Assert.Equal(200, getResult.StatusCode);

        var returnedMotivoList = getResult.Value as List<Motivo>;
        Assert.NotNull(returnedMotivoList);
        Assert.Equal(motivoList.Count, returnedMotivoList.Count);
    }
}
