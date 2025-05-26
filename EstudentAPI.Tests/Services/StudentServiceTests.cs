using Xunit;
using EstudentAPI.Models;
using EstudentAPI.Services;

namespace EstudentAPI.Tests.Services
{
    public class StudentServiceTests
    {
        [Fact]
        public void HasApproved_DariemConNotaAlta_ReturnsTrue()
        {
            var estudiante = new Estudiante { CI = 1001, Nombre = "Dariem", Nota = 85 };
            var service = new StudentService();

            var resultado = service.HasApproved(estudiante);

            Assert.True(resultado);
            Assert.Equal("Dariem", estudiante.Nombre);
            Assert.Equal(1001, estudiante.CI);
        }

        [Fact]
        public void HasApproved_EricConNotaLimite_ReturnsTrue()
        {
            var estudiante = new Estudiante { CI = 1002, Nombre = "Eric", Nota = 51 };
            var service = new StudentService();

            var resultado = service.HasApproved(estudiante);

            Assert.True(resultado);
            Assert.Equal("Eric", estudiante.Nombre);
            Assert.Equal(1002, estudiante.CI);
        }

        [Fact]
        public void HasApproved_AlessiaReprobada_ReturnsFalse()
        {
            var estudiante = new Estudiante { CI = 1003, Nombre = "Alessia", Nota = 45 };
            var service = new StudentService();

            var resultado = service.HasApproved(estudiante);

            Assert.False(resultado);
            Assert.Equal("Alessia", estudiante.Nombre);
            Assert.Equal(1003, estudiante.CI);
        }

        [Fact]
        public void HasApproved_AlondraReprobada_ReturnsFalse()
        {
            var estudiante = new Estudiante { CI = 1004, Nombre = "Alondra", Nota = 20 };
            var service = new StudentService();

            var resultado = service.HasApproved(estudiante);

            Assert.False(resultado);
            Assert.Equal("Alondra", estudiante.Nombre);
            Assert.Equal(1004, estudiante.CI);
        }
    }
}