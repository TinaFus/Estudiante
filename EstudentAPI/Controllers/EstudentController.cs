using Microsoft.AspNetCore.Mvc;
using EstudentAPI.Models;
using EstudentAPI.Services;
using System.Collections.Generic;


namespace EstudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

            public EstudentController(IStudentService studentService)
            {
                _studentService = studentService;
            }

        // GET: /Estudent
        [HttpGet]
        public List<Estudiante> GetAll()
        {
            return _studentService.GetAll();
        }

        // GET: /Estudent/{ci}
        [HttpGet("{ci}")]
        public Estudiante? GetById(int ci)
        {
            var estudiante = _studentService.GetById(ci);
            if (estudiante == null) return null;
            return estudiante;
            /*var estudiante = _studentService.GetById(ci);
            estudiante.Nombre = "Nombre Estándar"; // ← ⚠ Esto sobreescribe lo que Moq devuelve
            return estudiante;*/
        }

        // POST: /Estudent
        [HttpPost]
        public Estudiante Create(Estudiante estudiante)
        {
            return _studentService.Create(estudiante);
        }

        // PUT: /Estudent/{ci}
        [HttpPut("{ci}")]
        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            return _studentService.Update(ci, updatedEstudiante);
        }

        // DELETE: /Estudent/{ci}
        [HttpDelete("{ci}")]
        public Estudiante Delete(int ci)
        {
            return _studentService.Delete(ci);
        }
    }
}