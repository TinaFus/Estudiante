using Xunit;
using EstudentAPI.Models;
using EstudentAPI.Tests.Stubs;

namespace EstudentAPI.Tests.Stubs
{
    public class StubStudentServiceTests
    {
        [Fact]
        public void HasApproved_DeberiaRetornarTrueParaDariem()
        {
            var stub = new StudentServiceStub();
            var estudiante = stub.GetAll().FirstOrDefault(e => e.Nombre == "Dariem");

            var resultado = stub.HasApproved(estudiante!);

            Assert.True(resultado);
        }

        [Fact]
        public void HasApproved_DeberiaRetornarFalseParaAlessia()
        {
            var stub = new StudentServiceStub();
            var estudiante = stub.GetAll().FirstOrDefault(e => e.Nombre == "Alessia");

            var resultado = stub.HasApproved(estudiante!);

            Assert.False(resultado);
        }

        [Fact]
        public void GetAll_DeberiaRetornarDosEstudiantes()
        {
            var stub = new StudentServiceStub();

            var lista = stub.GetAll();

            Assert.Equal(2, lista.Count);
        }
    }
}