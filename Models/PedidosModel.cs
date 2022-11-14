using System.ComponentModel.DataAnnotations;

namespace RapiChicken.Models
{
    public class PedidosModel
    {
        public int Pedidos_id { get; set; }

        [Required(ErrorMessage ="El campo nombre de pedido es obligatorio")]
        public string N_Pedido{ get; set; } = null!;

        [Required(ErrorMessage = "El campo detalle de pedido es obligatorio")]
        public string D_Pedido { get; set; } = null!;

        [Required(ErrorMessage = "El campo stock de producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Solo numeros positivos")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo detalle de unidad es obligatorio")]
        public string NP_C { get; set; } = null!;
    }
}
