using Crm.Application.ViewModel;
using Crm.Application.UseCases.SubstatusUseCases;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Moq;
using AutoMapper;
using Crm.Application.AutoMapper;
using Crm.Application.UseCases.StatusSubstatusUseCase;
using Crm.Application.Requests;
using Crm.Infrastructure.Repositories;
using Crm.Application.UseCases.StatusUseCases;

namespace Crm.Tests.StatusSubstatusTest;
public class StatusSubstatusTest
{
    private readonly Mock<IStatusRepository> _statusRepositoryMock;
    private readonly Mock<ISubstatusRepository> _substatusRepositoryMock;
    private readonly Mock<IStatusSubstatusRepository> _statusSubstatusRepositoryMock;
    private readonly IMapper _mapper;
    private readonly CreateStatusSubstatusUseCase _service;

    public StatusSubstatusTest()
    {
        _statusRepositoryMock = new Mock<IStatusRepository>();
        _substatusRepositoryMock = new Mock<ISubstatusRepository>();
        _statusSubstatusRepositoryMock = new Mock<IStatusSubstatusRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateStatusSubstatusRequestVM, StatusSubstatus>();
        });
        _mapper = config.CreateMapper();

        _service = new CreateStatusSubstatusUseCase(
            _statusRepositoryMock.Object,
            _substatusRepositoryMock.Object,
            _statusSubstatusRepositoryMock.Object,
            _mapper
        );
    }

    [Fact]
    public void Execute_Should_Call_Repositories_When_Valid()
    {
        // Arrange
        var request = new CreateStatusSubstatusRequestVM
        {
            StatusId = 1,
            SubstatusId = 2
        };
        var status = new Status { Id = 1 };
        var substatus = new Substatus { Id = 2 };

        _statusRepositoryMock.Setup(x => x.GetById(request.StatusId)).Returns(status);
        _substatusRepositoryMock.Setup(x => x.GetById(request.SubstatusId)).Returns(substatus);

        // Act
        _service.Execute(request);

        // Assert
        _statusRepositoryMock.Verify(x => x.GetById(request.StatusId), Times.Once);
        _substatusRepositoryMock.Verify(x => x.GetById(request.SubstatusId), Times.Once);
        _statusSubstatusRepositoryMock.Verify(x => x.Create(It.IsAny<StatusSubstatus>()), Times.Once);
    }

    [Fact]
    public void Execute_Should_ThrowException_When_StatusNotFound()
    {
        // Arrange
        var request = new CreateStatusSubstatusRequestVM
        {
            StatusId = 1,
            SubstatusId = 2
        };

        _statusRepositoryMock.Setup(x => x.GetById(request.StatusId)).Returns((Status)null);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _service.Execute(request));
        Assert.Equal($"Status with ID {request.StatusId} not found.", exception.Message);
    }

    [Fact]
    public void Execute_Should_ThrowException_When_SubstatusNotFound()
    {
        // Arrange
        var request = new CreateStatusSubstatusRequestVM
        {
            StatusId = 1,
            SubstatusId = 2
        };
        var status = new Status { Id = 1 };

        _statusRepositoryMock.Setup(x => x.GetById(request.StatusId)).Returns(status);
        _substatusRepositoryMock.Setup(x => x.GetById(request.SubstatusId)).Returns((Substatus)null);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _service.Execute(request));
        Assert.Equal($"Substatus with ID {request.SubstatusId} not found.", exception.Message);
    }
}
