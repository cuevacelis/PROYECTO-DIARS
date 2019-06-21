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
    public class datTipoPersona
    {
        #region singleton
        private static readonly datTipoPersona UnicaInstancia = new datTipoPersona();
        public static datTipoPersona Instancia
        {
            get
            {
                return datTipoPersona.UnicaInstancia;
            }

        }
        #endregion singleton


        #region metodos
        public List<entTipoPersona> ListarTipoCliente()
        {
            SqlCommand cmd = null;
            List<entTipoPersona> lista = new List<entTipoPersona>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entTipoPersona TipoCliente = new entTipoPersona();
                    TipoCliente.idTipoCliente = Convert.ToInt16(dr["IdTipoCliente"]);
                    TipoCliente.desTipoCliente = dr["DesTipoCliente"].ToString();
                    TipoCliente.estTipoCliente = Convert.ToBoolean(dr["EstTipoCliente"]);

                    lista.Add(TipoCliente);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        #endregion metodos
    }
}
