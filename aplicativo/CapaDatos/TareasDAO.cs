using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TareasDAO : conexion
    {
        //Procedimiento que crea el DOC-ENTRY
        public string SP_create_documento()
        {
            try
            {
                string Doc = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_create_documento", conn);
                comando.CommandType = CommandType.StoredProcedure;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Doc = rpt["DOCUMENTO"].ToString();
                }
                return Doc;
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
        //Procedimiento para saber registrar el acceso
        public string SP_registro_ok(string id, DateTime fecha)
        {
            try
            {
                string ok = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_registro_ok", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    ok = rpt["ID_TBLGWBSYS"].ToString();
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
        //Procedimiento para saber registrar el acceso
        public string SP_registro_fail(string id, DateTime fecha,string error)
        {
            try
            {
                string ok = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_registro_fail", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;
                comando.Parameters.Add("@ERROR", SqlDbType.VarChar).Value = error;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    ok = rpt["ID_TBLGWBSYS"].ToString();
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
        //Procedimiento que incrementa en uno el DOC-ENTRY
        public string SP_incrementa_documento()
        {
            try
            {
                string Id = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_incrementa_documento", conn);
                comando.CommandType = CommandType.StoredProcedure;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id = rpt["DOC_ENTRY"].ToString();
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
        //Procedimiento que trae el ID de la zona
        public string SP_id_codigo(string codigo)
        {
            try
            {
                string Id_codigos = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id_codigos", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CODIGO", SqlDbType.VarChar, 15).Value = codigo;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id_codigos = rpt["ID_TBINCODEMTR"].ToString();

                }
                return Id_codigos;
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
        //Procedimiento que trae el ID de la zona
        public string SP_id_zona(string zona)
        {
            try
            {
                string Id_zona = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id_zona", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ZONA", SqlDbType.VarChar, 15).Value = zona;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id_zona = rpt["ID_TBCLZONE"].ToString();

                }
                return Id_zona;
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
        
        //Procedimiento que trae el ID del cliente
        public string SP_id_cliente(string usuario)
        {
            try
            {
                string Cli = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id_cliente", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Cli = rpt["ID_TBCLIENT"].ToString();
                }
                return Cli;
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

        //Procedimiento para guardar la tarea
        public string SP_guardar_tarea(string cliente, string zona, string codigo, string documento, string serial, string marca, string modelo, DateTime fecha)
        {
            try
            {
                string registro = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_guardar_tarea", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID_TBCLIENT", SqlDbType.Int).Value = cliente;
                comando.Parameters.Add("@ID_TBCLZONE", SqlDbType.Int).Value = zona;
                comando.Parameters.Add("@ID_TBINCODEMTR", SqlDbType.Int).Value = codigo;
                comando.Parameters.Add("@DOC_ENTRY", SqlDbType.VarChar).Value = documento;
                comando.Parameters.Add("@NUM_SERIAL", SqlDbType.VarChar).Value = serial;
                comando.Parameters.Add("@MARK", SqlDbType.VarChar).Value = marca;
                comando.Parameters.Add("@NAME_MODEL", SqlDbType.VarChar).Value = modelo;
                comando.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    registro = "ok";
                }
                return registro;
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
    }
}