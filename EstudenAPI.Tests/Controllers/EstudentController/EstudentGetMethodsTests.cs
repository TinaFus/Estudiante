using Xunit;
using EstudentAPI.Controllers;
using EstudentAPI.Models;
using EstudentAPI.Tests.Stubs;

namespace EstudentAPI.Tests.Controllers.EstudentController
{
    public class EstudentGetMethodsTests
    {
        [Fact]
        public void GetAll_ReturnsAllEstudiantes()
        {
            // Arrange
            var controller = new EstudentAPI.Controllers.EstudentController(new StudentServiceStub());

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Juan", result[0].Nombre);
            Assert.Equal("Ana", result[1].Nombre);
        }

        [Fact]
        public void GetById_ExistingCI_ReturnsCorrectEstudiante()
        {
            // Arrange
            var controller = new EstudentAPI.Controllers.EstudentController(new StudentServiceStub());

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.CI);
            Assert.Equal("Juan", result.Nombre);
            Assert.Equal(75, result.Nota);
        }

        [Fact]
        public void GetById_NonExistingCI_ReturnsNullOrDefault()
        {
            // Arrange
            var controller = new EstudentAPI.Controllers.EstudentController(new StudentServiceStub());

            // Act
            var result = controller.GetById(99); // no existe

            // Assert
            Assert.Null(result); // esto depende de tu implementación del stub
        }
    }
}