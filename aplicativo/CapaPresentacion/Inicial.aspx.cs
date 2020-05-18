using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CapaPresentacion
{
    public partial class Inicial : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["eliminar"] = false;
            Session["existencias"] = false;
            if (!IsPostBack)
            {
                DateTime fecha = DateTime.Today.AddDays(-15);
            }

            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                           //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            string cli = ci.getCliente();               //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                            //Pasa el valor de la lista
            usuario.Text = usu;                         //Pone nombre usuario
            cliente.Text = cli;                         //Pone nombre cliente
        }


        public bool ValidarCampos()
        {
            return true;
        }

        public bool Rango60()
        {
            return true;
        }




        protected void cerrar_Click(object sender, EventArgs e)
        {
            /*int salida;
            salida = Convert.ToInt32(logout.Value);//Toma el valor del contador
            Response.Write("<script language=javascript> alert('Respuesta es " + salida + "'); </script>");*/
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e)
        {
            actualiza();    //Proceso de actualizar
        }


        protected void actualiza()
        {
            bool revision = ValidarCampos();                                    //Valida las fechas
            if (revision == true)
            {
                bool dias = Rango60();
                if (dias == true)
                {
                    Consulta ca = new Consulta();                       //Crea una instancia de clase
                    string usu = Convert.ToString(Session["Login"]);    //Lee la variable Session
                    ca.Usuario = usu;                                   //Pasa el valor de usuario
                    string Id = ca.getId();                             //Pasa el metodo getId para validar si existe el usuario     
                    ca.Cliente = Id;                                    //Pasa el valor de la lista
                    DataTable dt = ca.getConsultaActualizar();          //Pasa el metodo consulta inicial
                    this.GridView1.DataSource = dt;                     //Agrega al GridView el dataset
                    GridView1.DataBind();

                    if (dt.Rows.Count <= 0)
                    {
                        exportar.Enabled = false;
                    } else
                    {
                        exportar.Enabled = true;
                    }
                }
            }
        }

        protected void tareas_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void exportar_click(object sender, EventArgs e)
        {
            actualiza();

                    StringWriter stringWrite = new StringWriter();
                    for (int i = 0; i <= (GridView1.Rows.Count - 1); i++)
                    {
                        stringWrite.WriteLine(GridView1.Rows[i].Cells[0].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[1].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[2].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[3].Text.ToString() + "\t"
                                + GridView1.Rows[i].Cells[4].Text.ToString() + "\t"
                                );
                        stringWrite.WriteLine("");
                    }
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=prueba.txt");
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.text";
                    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                    Response.Write(stringWrite.ToString());
                    Response.End();
        }

        protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}