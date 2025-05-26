using EstudentAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace EstudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private List<Estudiante> _estudiantes;

        public StudentService()
        {
            _estudiantes = new List<Estudiante>();
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetById(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante == null)
            {
                estudiante = new Estudiante
                {
                    CI = -1,
                    Nombre = "No Encontrado",
                    Nota = 0
                };
            }
            return estudiante;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            estudiante.CI = _estudiantes.Count > 0 ? _estudiantes.Max(e => e.CI) + 1 : 1;
            _estudiantes.Add(estudiante);
            return estudiante;
        }

        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante != null)
            {
                estudiante.Nombre = updatedEstudiante.Nombre;
                estudiante.Nota = updatedEstudiante.Nota;
            }
            return estudiante;
        }

        public Estudiante Delete(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.CI == ci);
            if (estudiante != null)
            {
                _estudiantes.Remove(estudiante);
            }
            return estudiante;
        }

        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}