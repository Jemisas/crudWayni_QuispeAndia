using System.ComponentModel.DataAnnotations;

namespace CRUD_Wayni_Quispe_Andia_Jeremy.Models
{
    /// <summary>
    /// Clase que representa a un usuario en el sistema.
    /// </summary>
    /// <author>Jeremy Quispe</author>
    public class User
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        /// <author>Jeremy Quispe</author>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        /// <remarks>El nombre solo debe contener letras y espacios.</remarks>
        /// <author>Jeremy Quispe</author>
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario.
        /// </summary>
        /// <author>Jeremy Quispe</author>
        public string Apellido { get; set; }

        /// <summary>
        /// Documento Nacional de Identidad (DNI) del usuario.
        /// </summary>
        /// <remarks>El DNI debe tener exactamente 8 dígitos y contener solo números.</remarks>
        /// <author>Jeremy Quispe</author>
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener exactamente 8 dígitos.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe contener solo números.")]
        public string DNI { get; set; }
    }
}