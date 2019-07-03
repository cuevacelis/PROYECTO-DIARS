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
    public class datBitacora
    {
        #region singleton
        private static readonly datBitacora _instancia = new datBitacora();
        public static datBitacora Instancia
        {
            get { return datBitacora._instancia; }
        }
        #endregion

        #region metodos
        public List<entBitacora> ListarBitacora(entUsuario u)
        {
            SqlCommand cmd = null;
            List<entBitacora> lista = new List<entBitacora>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerBitacoraPorUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidUsuario", u.idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entBitacora B = new entBitacora();
                    B.idBitacora = Convert.ToInt16(dr["idBitacora"]);
                    B.fecha = Convert.ToDateTime(dr["fecha"]);

                    entUsuario U = new entUsuario();
                    U.idUsuario = Convert.ToInt16(dr["idUsuario"]);

                    B.idUsuario = U;
                    lista.Add(B);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
    }
    #endregion
}
