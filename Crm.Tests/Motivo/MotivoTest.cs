using Crm.Application.UseCases.MotivoUseCase;
using Crm.Application.ViewModel.Motivo;
using Crm.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tests.Motivo
{
    public class MotivoTest
    {
        private readonly Mock<IMotivoRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly CreateMotivoUseCase _useCase;

        public MotivoTest()
        {
            _repositoryMock = new Mock<IMotivoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MotivoVM, Domain.Entities.Motivo>()
                    .ForMember(dest => dest.Atendimentos, opt => opt.Ignore()); // Ignora a propriedade Atendimentos no mapeamento
            });
            _mapper = config.CreateMapper();

            _useCase = new CreateMotivoUseCase(_repositoryMock.Object, _mapper);
        }

        [Fact]
        public void Execute_Should_Call_Repository_When_Valid()
        {
            // Arrange
            var motivo = new MotivoVM
            {
                Name = "Valid Name"
            };

            _repositoryMock.Setup(x => x.ExistsByName(motivo.Name)).Returns(false);

            // Act
            _useCase.Execute(motivo);

            // Assert
            _repositoryMock.Verify(x => x.ExistsByName(motivo.Name), Times.Once);
            _repositoryMock.Verify(x => x.Create(It.IsAny<Domain.Entities.Motivo>()), Times.Once);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_NameIsEmpty()
        {
            // Arrange
            var motivo = new MotivoVM
            {
                Name = ""
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(motivo));
            Assert.Equal("Fill in the name field.", exception.Message);
        }

        [Fact]
        public void Execute_Should_ThrowException_When_NameAlreadyExists()
        {
            // Arrange
            var motivo = new MotivoVM
            {
                Name = "Existing Name"
            };

            _repositoryMock.Setup(x => x.ExistsByName(motivo.Name)).Returns(true);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _useCase.Execute(motivo));
            Assert.Equal("A motivo with the same name already exists.", exception.Message);
        }
    }
}
