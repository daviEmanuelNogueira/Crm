using Crm.Application.ViewModel;
using Crm.Application.UseCases.SubstatusUseCases;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Moq;

namespace Crm.Tests.SubstatusTests;
public class SubstatusTest
{
    [Fact]
    public void Status_CanBeInitialized()
    {
        // Arrange
        var substatus = new Substatus();

        //Act
        ////

        // Assert
        Assert.NotNull(substatus);
    }

    [Fact]
    public void Execute_ValidDto_CreatesStatus()
    {
        // Arrange
        var mockRepository = new Mock<ISubstatusRepository>();
        var useCase = new CreateSubtatusUseCase(mockRepository.Object);
        var dto = new SubstatusVM
        {
            Name = "New Status",
            IsActivated = true
        };

        // Act
        useCase.Execute(dto);

        // Assert
        mockRepository.Verify(r => r.Create(It.IsAny<Substatus>()), Times.Once);
    }

    [Fact]
    public void Execute_NullName_ThrowsArgumentException()
    {
        // Arrange
        var mockRepository = new Mock<ISubstatusRepository>();
        var useCase = new CreateSubtatusUseCase(mockRepository.Object);

        var dto = new SubstatusVM
        {
            IsActivated = true
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => useCase.Execute(dto));
    }
}
