using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
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

public class AtendimentoIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    private const string BaseUrl = "api/atendimento";

    public AtendimentoIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Atendimento_Execute_ShouldCreateNewAtendimento()
    {
        // Arrange
        var newAtendimento = new AtendimentoVM
        {
            Name = "John Doe",
            Phone = "123456789",
            Observations = "Test observations",
            StatusSubstatusId = 1,
            MotivoId = 1
        };

        // Act
        var response = await _client.PostAsJsonAsync(BaseUrl, newAtendimento);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
