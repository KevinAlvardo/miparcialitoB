using Microsoft.EntityFrameworkCore;


namespace AM101820.Entities
{
    public class AM101820Context : DbContext
    {
        public AM101820Context(DbContextOptions<AM101820Context> options)
            : base(options)
        {
        }

        // DbSet para cada entidad en tu modelo
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de las relaciones y llaves primarias
            modelBuilder.Entity<Inscripcion>()
                .HasKey(i => new { i.EstudianteID, i.CursoID });

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Estudiante)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.EstudianteID);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Curso)
                .WithMany(c => c.Inscripciones)
                .HasForeignKey(i => i.CursoID);
        }
    }
}
