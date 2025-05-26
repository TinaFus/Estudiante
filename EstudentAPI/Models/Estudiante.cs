namespace EstudentAPI.Models
{
    public class Estudiante
    {
        public int CI { get; set; }           // Cédula de Identidad
        public string Nombre { get; set; }    // Nombre del estudiante
        public int Nota { get; set; }         // Nota final (de 0 a 100)
    }
}