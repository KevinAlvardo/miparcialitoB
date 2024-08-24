namespace AM101820.Entities
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string NombreCurso { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
