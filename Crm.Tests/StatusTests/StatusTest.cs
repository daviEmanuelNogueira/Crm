using Crm.Application.ViewModel;
using Crm.Application.UseCases.StatusUseCases;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Moq;
using Crm.Application.AutoMapper;

namespace Crm.Tests.StatusTests;

public class StatusTest
{
    [Fact]
    public void Status_CanBeInitialized()
    {
        // Arrange
        var status = new Status();

        //Act
        ////

        // Assert
        Assert.NotNull(status);
    }

    [Fact]
    public void Execute_ValidDto_CreatesStatus()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());

        // Arrange
        var mockRepository = new Mock<IStatusRepository>();
        var useCase = new CreateStatusUseCase(mockRepository.Object, config.CreateMapper());
        var dto = new StatusVM
        {
            Name = "New Status",
            IsActivated = true,
            IsFinisher = true
        };

        // Act
        useCase.Execute(dto);

        // Assert
        mockRepository.Verify(r => r.Create(It.IsAny<Status>()), Times.Once);
    }

    [Fact]
    public void Execute_NullName_ThrowsArgumentException()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());

        // Arrange
        var mockRepository = new Mock<IStatusRepository>();
        var useCase = new CreateStatusUseCase(mockRepository.Object, config.CreateMapper());

        var dto = new StatusVM
        {
            IsActivated = true,
            IsFinisher = false
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => useCase.Execute(dto));
    }

}