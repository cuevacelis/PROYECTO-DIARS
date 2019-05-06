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
    public class datMatPrima
    {
        private static readonly datMatPrima UnicaInstancia = new datMatPrima();
        public static datMatPrima Instancia
        {
            get
            {
                return datMatPrima.UnicaInstancia;
            }

        }
        public List<entMatPrima> ListarMatPrima()
        {
            SqlCommand cmd = null;
            List<entMatPrima> listam = new List<entMatPrima>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarMatPrima", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entMatPrima material = new entMatPrima();
                    material.desMaterial = dr["desMaterial"].ToString();
                    material.idMaterial = Convert.ToInt32(dr["idMaterial"]);
                    listam.Add(material);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return listam;
        }
    }
}
