using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class RolesModel
    {
        public int RolId { get; set; }

        [Required(ErrorMessage ="El campo nombre del rol es obligatorio")]
        public string NRol { get; set; } = null!;
		
		[Required(ErrorMessage ="El campo nombre del rol es obligatorio")]
        public string Descripcion { get; set; } = null!;

    }
}
