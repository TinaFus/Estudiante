using EstudentAPI.Models;
using System.Collections.Generic;

namespace EstudentAPI.Services
{
    public interface IStudentService
    {
        List<Estudiante> GetAll();
        Estudiante GetById(int ci);
        Estudiante Create(Estudiante estudiante);
        Estudiante Update(int ci, Estudiante updatedEstudiante);
        Estudiante Delete(int ci);

        bool HasApproved(Estudiante estudiante); // Método clave para Unit Testing
    }
}