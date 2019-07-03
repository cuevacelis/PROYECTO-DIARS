using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datPago
    {
        #region singleton
        private static readonly datPago UnicaInstancia = new datPago();
        public static datPago Instancia
        {
            get
            {
                return datPago.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entPago> ListarPago()
        {
            SqlCommand cmd = null;
            List<entPago> lista = new List<entPago>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPago Pago = new entPago();
                    entHospedaje Hospedaje = new entHospedaje();
                    entPersona Persona = new entPersona();

                    Pago.idPago = Convert.ToInt32(dr["IdPago"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    Pago.modoDePago = dr["ModoDePago"].ToString();
                    Pago.monto = Convert.ToInt32(dr["monto"]);
                    Pago.estPago = Convert.ToBoolean(dr["estPago"]);

                    Persona.nombreyApellidoPersona = dr["Nombres"].ToString();
                    Persona.telefono = Convert.ToInt32(dr["Telefono"]);
                    Pago.idPersona = Persona;

                    //Hospedaje.idHospedaje = Convert.ToInt16(dr["idHospedaje"]);
                    Hospedaje.fechaLlegada = Convert.ToDateTime(dr["FechaLlegada"]);
                    Hospedaje.fechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                    Pago.idHospedaje = Hospedaje;

                    lista.Add(Pago);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarPago(entPago P)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombres", P.idPersona.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", P.idPersona.DNI);
                cmd.Parameters.AddWithValue("@prmIdTipoPersona", P.idPersona.idTipoPersona.idTipoPersona);

                cmd.Parameters.AddWithValue("@prmintMonto", P.monto);
                cmd.Parameters.AddWithValue("@prmstrModoDePago", P.modoDePago);
                cmd.Parameters.AddWithValue("@prmboolEstPago", P.estPago);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { insertar = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return insertar;
        }
        #endregion
    }
}
