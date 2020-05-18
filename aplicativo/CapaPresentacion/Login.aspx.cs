using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            theDiv.Visible = false;
        }

       protected void Iniciar_Click(object sender, EventArgs e)
        {
            Logeo em = new Logeo();       //Crea una instancia de clase
            em.Usuario = Usuario.Text;          //Toma el valor del Textbox usuario
            em.Contraseña = Contraseña.Text;    //Toma el valor del Textbox contraseña
            string ok = em.inicio_sesion();     //Pasa el metodo inicio de sesion

                string Id = em.getId();             //Pasa el metodo getId para validar si existe el usuario     
                string bloqueo = em.getBloqueo();   //Pasa el metodo getBloqueo
                string activo = em.getActivo();     //Pasa el metodo getActivo
                int contador = 0;                   //Contador para intentos de login

                if (Id != "")//Valida si existe el usuario
                {

                    if (bloqueo == "1")//Valida si esta bloqueado
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Bloqueado. Contacte al Administrador');</script>");
                    }
                    else
                    {
                        if (activo == "0")//Valida si esta activo
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario Deshabilitado. Contacte al administrador');</script>");
                        }
                        else
                        {
                            if (ok == "true")//Valida si es correcto clave y contraseña
                            {
                                string acceso = em.getAccede();//Registra en tabla login el acceso
                                Session["Login"] = Usuario.Text;//Asigna usuario a variable Session
                                Response.Redirect("Inicial.aspx");//Redirecciona al menu
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Bienvenido a MWCT10. '" + Usuario.Text + "');</script>");

                            }
                            else
                            {

                                contador = Convert.ToInt32(TextoContador.Value);//Toma el valor del contador

                                if (contador == 3)//Valida si es igual a 3
                                {
                                    Usuario.Text = string.Empty;        //Limpia campo usuario
                                    Contraseña.Text = string.Empty;     //Limpia campo contraseña
                                    string bloqueado = em.getBloquear();//Bloquea el usuario
                                    Response.Write("<script language=javascript> alert('Usuario bloqueado " + contador + " intentos fallidos'); </script>");
                                    TextoContador.Value = "0";          //Pone el nuevo valor en el campo
                                }
                                else
                                {
                                    Usuario.Text = string.Empty;    //Limpia campo usuario
                                    Contraseña.Text = string.Empty; //Limpia campo contraseña
                                    contador = contador + 1;        //Suma uno al contador
                                    TextoContador.Value = Convert.ToString(contador); //Pone el nuevo valor en el campo
                                    Response.Write("<script language=javascript> alert('Contraseña errada'); </script>");
                                    Response.Write("<script language=javascript> alert('Intento fallido No " + contador + "'); </script>");
                                }
                            }
                        }

                    }

                }
                else
                {
                    Usuario.Text = string.Empty;    //Limpia campo usuario
                    Contraseña.Text = string.Empty; //Limpia campo contraseña
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Usuario invalido');</script>");
                }
        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            theDiv.Visible = true;
        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}