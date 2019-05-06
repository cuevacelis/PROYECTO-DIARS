using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datColor
    {
        #region singleton
        private static readonly datColor UnicaInstancia = new datColor();
        public static datColor Instancia
        {
            get
            {
                return datColor.UnicaInstancia;
            }

        }
        public List<entColor> ListarColor()
        {
            SqlCommand cmd = null;
            List<entColor> listac = new List<entColor>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entColor color = new entColor();
                    color.desColor = dr["desColor"].ToString();
                    color.idColor = Convert.ToInt32(dr["idColor"]);
                    listac.Add(color);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return listac;
        }
        #endregion singleton

    }
}
