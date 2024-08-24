namespace AM101820.Entities
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
