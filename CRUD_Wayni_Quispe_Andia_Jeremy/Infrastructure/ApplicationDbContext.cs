using Microsoft.EntityFrameworkCore;
using CRUD_Wayni_Quispe_Andia_Jeremy.Models;

namespace CRUD_Wayni_Quispe_Andia_Jeremy.Infrastructure
{
    /// <summary>
    /// Contexto de la aplicación para interactuar con la base de datos.
    /// </summary>
    /// <author>Jeremy Quispe</author>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor que inicializa el contexto de la aplicación con las opciones especificadas.
        /// </summary>
        /// <param name="options">Opciones para el contexto de la base de datos.</param>
        /// <author>Jeremy Quispe</author>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Conjunto de entidades de usuarios.
        /// </summary>
        /// <author>Jeremy Quispe</author>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Configura el modelo creando datos iniciales para la base de datos.
        /// </summary>
        /// <param name="modelBuilder">El generador de modelos.</param>
        /// <author>Jeremy Quispe</author>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Nombre = "Juan", Apellido = "Pérez", DNI = "12345678" },
                new User { Id = 2, Nombre = "María", Apellido = "Lopez", DNI = "87654321" },
                new User { Id = 3, Nombre = "Pedro", Apellido = "Gomez", DNI = "23456789" },
                new User { Id = 4, Nombre = "Ana", Apellido = "Martinez", DNI = "98765432" },
                new User { Id = 5, Nombre = "Luis", Apellido = "Garcia", DNI = "34567890" },
                new User { Id = 6, Nombre = "Carla", Apellido = "Fernandez", DNI = "45678901" },
                new User { Id = 7, Nombre = "Miguel", Apellido = "Rodriguez", DNI = "56789012" },
                new User { Id = 8, Nombre = "Sofia", Apellido = "Castro", DNI = "67890123" },
                new User { Id = 9, Nombre = "Alberto", Apellido = "Diaz", DNI = "78901234" },
                new User { Id = 10, Nombre = "Lucia", Apellido = "Ruiz", DNI = "89012345" },
                new User { Id = 11, Nombre = "Ricardo", Apellido = "Santos", DNI = "90123456" },
                new User { Id = 12, Nombre = "Valeria", Apellido = "Morales", DNI = "01234567" },
                new User { Id = 13, Nombre = "Fernando", Apellido = "Gutierrez", DNI = "11223344" },
                new User { Id = 14, Nombre = "Paola", Apellido = "Mejia", DNI = "22334455" },
                new User { Id = 15, Nombre = "Hernán", Apellido = "Rojas", DNI = "33445566" },
                new User { Id = 16, Nombre = "Diana", Apellido = "Cruz", DNI = "44556677" },
                new User { Id = 17, Nombre = "Jorge", Apellido = "Mendoza", DNI = "55667788" },
                new User { Id = 18, Nombre = "Claudia", Apellido = "Ortega", DNI = "66778899" },
                new User { Id = 19, Nombre = "Felipe", Apellido = "Villanueva", DNI = "77889900" },
                new User { Id = 20, Nombre = "Camila", Apellido = "Navarro", DNI = "88990011" }
            );
        }
    }
}
