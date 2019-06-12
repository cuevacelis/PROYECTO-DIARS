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
    public class datDetalle
    {
        #region singleton
        private static readonly datDetalle UnicaInstancia = new datDetalle();
        public static datDetalle Instancia
        {
            get
            {
                return datDetalle.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entDetalle> ListarDetalle()
        {
            SqlCommand cmd = null;
            List<entDetalle> lista = new List<entDetalle>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entDetalle Detalle = new entDetalle();
                    entCliente Cliente = new entCliente();

                    Detalle.idDetalle = Convert.ToInt16(dr["IdDetalle"]);
                    //Detalle.idCliente = Convert.ToInt16(dr["IdCliente"]);
                    Detalle.adultos = Convert.ToInt16(dr["Adultos"]);
                    Detalle.ninios = Convert.ToInt16(dr["Ninios"]);

                    Cliente.nombreCliente = dr["NombreCliente"].ToString();
                    Cliente.apellidoCliente = dr["ApellidoCliente"].ToString();

                    Detalle.idCliente = Cliente;
                    lista.Add(Detalle);
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
