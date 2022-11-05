using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class PersonalModel
    {
        public int PersonalId { get; set; }

        [Required(ErrorMessage ="El campo nombres es obligatorio")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        public string NPersonal { get; set; } = null!;
		
		[Required(ErrorMessage ="El campo apellidos es obligatorio")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        public string APersonal { get; set; } = null!;

        [Required(ErrorMessage = "El campo telefono/Celular es obligatorio")]
        [MinLength(6, ErrorMessage = "Telefono/Celular debe de tener minimo 6 y maximo 9 dígitos")]
        [MaxLength(9, ErrorMessage = "Telefono/Celular debe de tener minimo 6 y maximo 9 dígitos")]
        public int PTel { get; set; }
        
        [Required(ErrorMessage ="El campo fecha de nacimiento es obligatorio")]
        public DateTime FN { get; set; }
		
		[Required(ErrorMessage = "El campo DNI es obligatorio")]
		[MinLength(8, ErrorMessage = "DNI debe de tener 8 dígitos")]
        [MaxLength(8, ErrorMessage = "DNI debe de tener 8 dígitos")]
		public int Dni { get; set; }

        [Required(ErrorMessage = "El campo direccion es obligatorio")]
        public string Dir { get; set; } = null!;
		
		[Required(ErrorMessage = "El campo sexo es obligatorio(f/m)")]
		public char sex { get; set; }
		
		public int RolesId { get; set; }
		
		[Required(ErrorMessage = "El campo rol es obligatorio")]
		public string NRoles { get; set; } = null!;
		
		public string Descripcion { get; set; } = null!;
    }
}
		
