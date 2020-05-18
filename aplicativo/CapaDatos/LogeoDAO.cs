using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class LogeoDAO : conexion
    {
        public string SP_inicio_Sesion(string usuario, string contraseña)//Procedimiento para inicio de sesion
        {
            try
            {
                string ok = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_inicio_Sesion", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;
                comando.Parameters.Add("@PASS", SqlDbType.VarChar, 15).Value = contraseña;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    ok = rpt["true"].ToString();
                }
                return ok;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_id(string usuario)//Procedimiento que trae el ID del usuario
        {
            try
            {
                string Id = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id = rpt["ID_TBCLIENT"].ToString();

                }
                return Id;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_bloqueo(string usuario)//Procedimiento que trae el campo de bloqueo del usuario
        {
            try
            {
                string bloqueo = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_bloqueo", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    bloqueo = rpt["WEB_LOCKED"].ToString();
                }
                return bloqueo;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }
        public string SP_activo(string usuario)//Procedimiento que trae si esta activo o no el usuario
        {
            try
            {
                string activo = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_activo", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    activo = rpt["WEB_ENABLE"].ToString();

                }
                return activo;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_bloquear(string usuario)//Procedimiento para saber si esta bloqueado o no el usuario
        {
            try
            {
                string bloqueado = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_bloquear", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    bloqueado = rpt["WEB_LOCKED"].ToString();
                }
                return bloqueado;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_acceder(string id, DateTime fecha)//Procedimiento para saber registrar el acceso
        {
            try
            {
                string acceder = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_acceder", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    acceder = rpt["ID_TBLGWBSYS"].ToString();
                }
                return acceder;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_salida(string id, DateTime fecha)//Procedimiento para saber registrar la salida
        {
            try
            {
                string salida = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_salida", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    salida = rpt["ID_TBLGWBSYS"].ToString();
                }
                return salida;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }
        public DataSet DSET(string sentencia)
        {
            DataSet ds = new DataSet();

            conn.Open();

            try
            {
                SqlDataAdapter SDA = new SqlDataAdapter(sentencia, conn);
                SDA.Fill(ds, "datos");
            }
            catch (SqlException mise)
            {
                int error = Convert.ToInt32(mise);
            }

            return ds;
        }
    }
}
