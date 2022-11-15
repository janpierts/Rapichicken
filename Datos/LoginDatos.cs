using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
	public class LoginDatos
	{
		public InventarioModel ObtenerId(int I_ID)
        {
            var oI_ID = new InventarioModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdInventario", con);
                cmd.Parameters.AddWithValue("I_ID",I_ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
					
                    while (dr.Read())
                    {
                        oI_ID.InventarioId = Convert.ToInt32(dr["Inventario_id"]);
                        oI_ID.NProducto = dr["n_producto"].ToString();
                        oI_ID.Descripcion = dr["descripcion"].ToString();
                        oI_ID.TipoProducto = dr["tipo_producto"].ToString();
                        oI_ID.EstadoProducto = dr["estado_producto"].ToString();
                        oI_ID.Stock = Convert.ToInt32(dr["stock"]);
                        oI_ID.DetalleUnidad = dr["detalle_unidad"].ToString();
						
                    }
                }
            }
            return oI_ID;
        }
	}
}
