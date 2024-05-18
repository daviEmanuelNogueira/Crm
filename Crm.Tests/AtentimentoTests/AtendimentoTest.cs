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
using Crm.Application.UseCases.AtendimentoUseCase;

namespace Crm.Tests.AtendimentoTests
{
    public class AtendimentoTest
    {
        private readonly Mock<IStatusSubstatusRepository> _statusSubstatusRepositoryMock;
        private readonly Mock<IMotivoRepository> _motivoRepositoryMock;
        private readonly Mock<IAtendimentoRepository> _atendimentoRepositoryMock;
        private readonly IMapper _mapper;
        private readonly CreateAtendimentoUseCase _useCase;

        public AtendimentoTest()
        {
            _statusSubstatusRepositoryMock = new Mock<IStatusSubstatusRepository>();
            _motivoRepositoryMock = new Mock<IMotivoRepository>();
            _atendimentoRepositoryMock = new Mock<IAtendimentoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AtendimentoVM, Atendimento>();
            });
            _mapper = config.CreateMapper();

            _useCase = new CreateAtendimentoUseCase(
                _statusSubstatusRepositoryMock.Object,
                _motivoRepositoryMock.Object,
                _mapper,
                _atendimentoRepositoryMock.Object
            );
        }

        [Fact]
        public void Execute_Should_Call_Repositories_When_Valid()
        {
            // Arrange
            var atendimento = new AtendimentoVM
            {
                Name = "Valid Name",
                Phone = "1234567890",
                Observations = "Valid Observation",
                StatusSubstatusId = 1,
                MotivoId = 1
            };
            var motivo = new Domain.Entities.Motivo { Id = 1 };
            var statusSubstatus = new StatusSubstatus { Id = 1 };

            _motivoRepositoryMock.Setup(x => x.GetById(atendimento.MotivoId)).Returns(motivo);
            _statusSubstatusRepositoryMock.Setup(x => x.GetById(atendimento.StatusSubstatusId)).Returns(statusSubstatus);

            // Act
            _useCase.Execute(atendimento);

            // Assert
            _motivoRepositoryMock.Verify(x => x.GetById(atendimento.MotivoId), Times.Once);
            _statusSubstatusRepositoryMock.Verify(x => x.GetById(atendimento.StatusSubstatusId), Times.Once);
            _atendimentoRepositoryMock.Verify(x => x.Cadastrar(It.IsAny<Atendimento>()), Times.Once);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_NameIsEmpty()
        {
            // Arrange
            var atendimento = new AtendimentoVM
            {
                Name = "",
                Phone = "1234567890",
                Observations = "Valid Observation",
                StatusSubstatusId = 1,
                MotivoId = 1
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(atendimento));
            Assert.Equal("Name is required.", exception.Message);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_PhoneIsEmpty()
        {
            // Arrange
            var atendimento = new AtendimentoVM
            {
                Name = "Valid Name",
                Phone = "",
                Observations = "Valid Observation",
                StatusSubstatusId = 1,
                MotivoId = 1
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(atendimento));
            Assert.Equal("Phone is required.", exception.Message);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_MotivoIsInvalid()
        {
            // Arrange
            var atendimento = new AtendimentoVM
            {
                Name = "Valid Name",
                Phone = "1234567890",
                Observations = "Valid Observation",
                StatusSubstatusId = 1,
                MotivoId = 1
            };

            _motivoRepositoryMock.Setup(x => x.GetById(atendimento.MotivoId)).Returns((Domain.Entities.Motivo)null);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(atendimento));
            Assert.Equal("Motivo is invalid.", exception.Message);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_StatusSubstatusIsInvalid()
        {
            // Arrange
            var atendimento = new AtendimentoVM
            {
                Name = "Valid Name",
                Phone = "1234567890",
                Observations = "Valid Observation",
                StatusSubstatusId = 1,
                MotivoId = 1
            };

            _motivoRepositoryMock.Setup(x => x.GetById(atendimento.MotivoId)).Returns(new Domain.Entities.Motivo { Id = 1 });
            _statusSubstatusRepositoryMock.Setup(x => x.GetById(atendimento.StatusSubstatusId)).Returns((StatusSubstatus)null);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(atendimento));
            Assert.Equal("Status Substatus is invalid.", exception.Message);
        }
    }
}