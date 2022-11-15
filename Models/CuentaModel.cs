using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class CuentaModel
    {
        public int PersonalId { get; set; }

        [Required(ErrorMessage ="El campo nombres es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras")]
        public string NPersonal { get; set; } = null!;
		
		[Required(ErrorMessage ="El campo apellidos es obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras")]
        public string APersonal { get; set; } = null!;

        [Required(ErrorMessage = "El campo telefono/Celular es obligatorio")]
		[RegularExpression(@"^[0-9]{6,9}$", ErrorMessage = "El telefono solo tiene (6-9)digitos")]
        public int PTel { get; set; }
        
        [Required(ErrorMessage ="El campo fecha de nacimiento es obligatorio")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime),"1/1/1938","1/1/2005", ErrorMessage = "La fecha de nacimiento no permitidad, la fecha deben estar en el rango de 1/1/1938 y 1/1/2005 ")]
        public DateTime FN { get; set; }
		
		[Required(ErrorMessage = "El campo DNI es obligatorio")]
		[RegularExpression(@"^[0-9]{8}$", ErrorMessage = "DNI debe de tener solo(8) numeros")]
		public int Dni { get; set; }

        [Required(ErrorMessage = "El campo direccion es obligatorio")]
        public string Dir { get; set; } = null!;
		
		[Required(ErrorMessage = "El campo sexo es obligatorio(f/m)")]
		[RegularExpression(@"^[m,fM,F]+$", ErrorMessage = "escriba f para femenino y m para masculino")]
		public char sex { get; set; }
		
		public int RolesId { get; set; }
		
		[Required(ErrorMessage = "El campo rol es obligatorio")]
		public string NRoles { get; set; } = null!;
		
		public string Descripcion { get; set; } = null!;
        
		[Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string NU { get; set; } = null!;
        
		[Required(ErrorMessage = "El Password es obligatorio")]
        public string PU { get; set; } = null!;
    }
}
		
