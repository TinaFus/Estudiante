using EstudentAPI.Models;
using EstudentAPI.Services;

namespace EstudentAPI.Tests.Stubs
{
    public class StudentServiceStub : IStudentService
    {
        private List<Estudiante> _estudiantes;

        public StudentServiceStub()
        {
            _estudiantes = new List<Estudiante>
            {
                new Estudiante { CI = 1, Nombre = "Juan", Nota = 75 },
                new Estudiante { CI = 2, Nombre = "Ana", Nota = 40 }
            };
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetById(int ci)
        {
            return _estudiantes.FirstOrDefault(e => e.CI == ci)!;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            estudiante.CI = _estudiantes.Max(e => e.CI) + 1;
            return estudiante;
        }

        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            return updatedEstudiante;
        }

        public Estudiante Delete(int ci)
        {
            return _estudiantes.FirstOrDefault(e => e.CI == ci)!;
        }

        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}