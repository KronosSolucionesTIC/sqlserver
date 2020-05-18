using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class cargueDAO : conexion
    {

        public string SP_get_zona(string zona)//Procedimiento que trae el ID del usuario
        {
            try
            {
                string Id_zona = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_get_zona", conn);
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
    }
}