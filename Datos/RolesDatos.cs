using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
    public class RolesDatos
    {
        public List<RolesModel> Listar()
        {
            var oLista = new List<RolesModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new RolesModel()
                        {
                            RolId = Convert.ToInt32(dr["Roles_id"]),
                            NRol = dr["name"].ToString(),
                            Descripcion = dr["description"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public RolesModel ObtenerId(int ID)
        {
            var oI_ID = new RolesModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdRoles", con);
                cmd.Parameters.AddWithValue("R_ID",ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oI_ID.RolId = Convert.ToInt32(dr["Roles_id"]);
                        oI_ID.NRol = dr["name"].ToString();
                        oI_ID.Descripcion = dr["description"].ToString();
                    }
                }
            }
            return oI_ID;
        }
        public List<InventarioModel> ListarN(string NP)
        {
            var oListaN = new List<InventarioModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarNInventario", con);
                cmd.Parameters.AddWithValue("NombreP", NP);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaN.Add(new InventarioModel()
                        {
                            InventarioId = Convert.ToInt32(dr["Inventario_id"]),
                            NProducto = dr["n_producto"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                            TipoProducto = dr["tipo_producto"].ToString(),
                            EstadoProducto = dr["estado_producto"].ToString(),
                            Stock = Convert.ToInt32(dr["stock"]),
                            DetalleUnidad = dr["detalle_unidad"].ToString()
                        });
                    }
                }
            }
            return oListaN;
        }

        public bool Guardar(RolesModel oGuardarR)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarRoles", con);
                    cmd.Parameters.AddWithValue("NR", oGuardarR.NRol);
                    cmd.Parameters.AddWithValue("D", oGuardarR.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(RolesModel oEditarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarRoles", con);
                    cmd.Parameters.AddWithValue("R_Id", oEditarI.RolId);
                    cmd.Parameters.AddWithValue("NR", oEditarI.NRol);
                    cmd.Parameters.AddWithValue("D", oEditarI.Descripcion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        
        public bool EditarS(InventarioModel oEditarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarStock", con);
                    cmd.Parameters.AddWithValue("I_Id", oEditarI.InventarioId);
                    cmd.Parameters.AddWithValue("I_Stock", oEditarI.Stock);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int ID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarRoles", con);
                    cmd.Parameters.AddWithValue("R_Id", ID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
