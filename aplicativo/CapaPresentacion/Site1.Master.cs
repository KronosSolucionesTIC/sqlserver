using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void consulta(object sender, EventArgs e)
        {
            Session["existencias"] = false;
            Response.Redirect("Inicial.aspx");//Redirecciona consulta tarea   
        }
        protected void archivo(object sender, EventArgs e)
        {
            Session["existencias"] = false;
            Response.Redirect("Archivo.aspx");//Redirecciona consulta tarea   
        }
        protected void creacion(object sender, EventArgs e)
        {
            Session["existencias"] = false;
            Response.Redirect("Creacion.aspx");//Redirecciona consulta tarea   
        }

        protected void creacion_click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToBoolean(Session["existencias"]) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#creacionModal').modal('show');</script>");
            }
            else
            {
                Response.Redirect("Creacion.aspx");//Redirecciona consulta tarea
            }
        }

        protected void cargar_click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToBoolean(Session["existencias"]) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#archivoModal').modal('show');</script>");
            }
            else
            {
                Response.Redirect("Archivo.aspx");//Redirecciona cargue por archivo plano
            }
        }

        protected void consultar_click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToBoolean(Session["existencias"]) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#consultaModal').modal('show');</script>");
            }
            else
            {
                Response.Redirect("Inicial.aspx");//Redirecciona consulta tarea
            }
        }

        protected void documentos_btn_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
    }
