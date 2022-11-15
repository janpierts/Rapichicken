using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
	public class LoginDatos
	{
		/*public bool Login(LoginModel oI_ID)
        {
            bool rpta;
			CuentaModel _CuentaModel = new CuentaModel();
			
			try
			{
			var cn = new Conexion();
			using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Login", con);
                    cmd.Parameters.AddWithValue("NP", oI_ID.NU);
                    cmd.Parameters.AddWithValue("AP", oI_ID.PU);
					cmd.CommandType = CommandType.StoredProcedure;
                    
					using(var dr = cmd.ExecuteReader())
					{
						while(dr.Read())
						{
							_CuentaModel.PersonalId = Convert.ToInt32(dr["Personas_id"]);
							_CuentaModel.NPersonal = dr["nombres"].ToString();
							_CuentaModel.APersonal = dr["apellidos"].ToString();
							_CuentaModel.PTel = Convert.ToInt32(dr["telefono"]);
							_CuentaModel.FN = Convert.ToDateTime(dr["f_nacimiento"]);
							_CuentaModel.Dni = Convert.ToInt32(dr["dni"]);
							_CuentaModel.Dir = dr["direccion"].ToString();
							_CuentaModel.sex = Convert.ToChar(dr["sexo"]);
							_CuentaModel.RolesId = Convert.ToInt32(dr["Roles_id"]);
							_CuentaModel.NRoles = dr["name"].ToString();
							_CuentaModel.Descripcion = dr["description"].ToString();
						}
					}
                }
			rpta = true;
			}
			catch (Exception e)
			{
				string error = e.Message;
                rpta = false;
			}
			return rpta;
		}*/
	}
}
