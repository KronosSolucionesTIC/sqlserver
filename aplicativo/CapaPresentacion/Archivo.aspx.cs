using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using System.Data.OleDb;

namespace CapaPresentacion
{
    public partial class Archivo : System.Web.UI.Page
    {
        #region "Metodos ADO.NET"
        private void procesarArchivoTxt()
        {
            List<string> lista = leerArchivoTxt();
            DataTable dt = getDataTableTxt(lista);
            gv.DataSource = dt;
            gv.DataBind();
            //Valida campos en blanco
            bool lleno = valida_vacio();
            if(lleno == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#camposModal').modal('show');</script>");
            }
        }

        private List<string> leerArchivoTxt()
        {
            int counter = 0;
            string line;
            List<string> listaLine = new List<string>();
            string ruta = Server.MapPath("~/tmp/archivotmp.csv");

            using (System.IO.StreamReader archivo = new System.IO.StreamReader(ruta))
            {
                while ((line = archivo.ReadLine()) != null)
                {
                    listaLine.Add(line);
                    counter++;
                }
            }

            return listaLine;
        }
        /// Obtiene el data table de un archivo con extension .csv que se leyo previamente
        /// <param name="lista">Lista de datos del archivo csv</param>

        private System.Data.DataTable getDataTableTxt(List<string> lista)
        {
            DataTable dt = armandoColumnDataTable();
            foreach (string item in lista)
            {
                string[] ListItems = item.Split(';');
                dt.Rows.Add(ListItems);
            }
            return dt;
        }

        /// Armando un data table para la carga de los archivos
        private DataTable armandoColumnDataTable()
        {
            DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Serial");
            dt.Columns.Add("Marca");
            dt.Columns.Add("Modelo");

            return dt;
        }
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        #endregion

        #region "Metodos"

        /// <summary>
        /// Leé el archivo csv para despues procesarlo
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Procesa el archivo con extensión .csv
        /// </summary>



        /// <summary>
        /// Verifica si la extension es correcta del archivo.
        /// Las extenciones válidas son txt, xls, xlsx, csv
        /// </summary>
        /// <param name="extencion">Exteción del archivo a evaluar</param>
        /// <returns></returns>
        private bool isExtencion(string extencion)
        {
            List<string> listaExteciones = new List<string>
                {
                    ".csv"
                };
            return listaExteciones.Exists(ex => ex == extencion.ToLower());
        }

        #endregion

        #region "Contructor"
        #endregion

        /// <summary>
        /// Procesa los archivos suvidos por el uploadFile :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Consulta ci = new Consulta();               //Crea una instancia de clase
            string usu = Convert.ToString(Session["Login"]); //Lee la variable Session
            ci.Usuario = usu;                           //Pasa el valor de usuario
            string Id = ci.getId();                     //Pasa el metodo getId para validar si existe el usuario     
            string cli = ci.getCliente();               //Pasa el metodo getId para validar si existe el usuario     
            ci.Cliente = Id;                            //Pasa el valor de la lista
            usuario.Text = usu;                         //Pone nombre usuario
            cliente.Text = cli;                         //Pone nombre cliente

            if (!IsPostBack)
            {
                llenar_zona();                              //Pasa funcion para llenar lista
                llenar_codigos();                           //Pasa funcion para llenar lista 
            }
        }

        protected void llenar_zona()
        {
            Medidor med = new Medidor();               //Crea una instancia de clase
            DataTable dt = med.getZona();   //Pasa el metodo consulta inicial
            zona.Items.Clear();
            zona.AppendDataBoundItems = true;
            zona.Items.Add("Seleccione...");
            this.zona.DataSource = dt;            //Agrega al GridView el dataset
            zona.DataTextField = "NAME_ZONE";     //Selecciona el campo a mostrar
            zona.DataValueField = "NAME_ZONE";    //Selecciona el campo para el valor
            zona.SelectedValue = "GLOBAL";      //Selecciona por defecto "Global"
            zona.DataBind();
        }

        protected void llenar_codigos()
        {
            Medidor med = new Medidor();               //Crea una instancia de clase
            DataTable dt = med.getCodigos();   //Pasa el metodo consulta inicial
            codigos.Items.Clear();
            codigos.AppendDataBoundItems = true;
            codigos.Items.Add("Seleccione...");
            this.codigos.DataSource = dt;            //Agrega al GridView el dataset
            codigos.DataTextField = "CODE";     //Selecciona el campo a mostrar
            codigos.DataValueField = "CODE";    //Selecciona el campo para el valor
            codigos.DataBind();
        }

        protected bool valida_vacio()
        {
            //Recorro array validando registros
            foreach (GridViewRow row in gv.Rows)
            {
                string ser = row.Cells[0].Text;
                string mar = row.Cells[1].Text;
                string mod = row.Cells[2].Text;

                if(ser == "&nbsp;")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#blancoModal').modal('show');</script>");
                    return false;
                }
                if (mar == "&nbsp;")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#blancoModal').modal('show');</script>");
                    return false;
                }
                if (mod == "&nbsp;")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#blancoModal').modal('show');</script>");
                    return false;
                }
            }
            return true;
        }
        protected void cerrar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            bool isArchivo = false;
            string ruta = Server.MapPath("~/tmp/archivotmp");

            //Verifica si el componente uploadFile contiene un archivo
            if (fuPrueba.HasFile)
            {

                string archivoExtension = System.IO.Path.GetExtension(fuPrueba.FileName).ToLower();
                isArchivo = this.isExtencion(archivoExtension);//Verifica si las exteciones son correctas

                if (isArchivo)
                {
                    try
                    {
                        if (System.IO.File.Exists(ruta + archivoExtension))
                        {
                            System.IO.File.Delete(ruta + archivoExtension);//Si existe el archivo temporal se lo elimina para crear el nuevo archivo
                        }

                        fuPrueba.PostedFile.SaveAs(ruta + archivoExtension);
                        lblMensaje.Text = "Archivo cargado correctamente";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;

                        switch (archivoExtension)
                        {
                            case ".csv":
                                procesarArchivoTxt();
                                break;
                            default:
                                //Not tiene implementación :(
                                break;
                        }
                    }
                    catch (Exception m)
                    {
                        lblMensaje.Text = "ocurrio un problema en el cargado del archivo"
                            + Environment.NewLine + m.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se puede cargar el archivo ya que no es valido";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void salvar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                string zona = row.Cells[6].Text;
                string idZona = reemplazarZona(zona);
            }
        }

        protected string reemplazarZona(string zona)
        {
            Cargue ca = new Cargue();               //Crea una instancia de clase
            ca.Zona = zona;                           //Pasa el valor de zona
            string idZona = ca.getZona();                     //Pasa el metodo getId para validar si existe el usuario                int idZona = 1;
            return idZona;
        }

        protected void limpiar_tabla(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void completar_tabla(object sender, EventArgs e)
        {
            llenar_tabla();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#Contenido_guardar_archivo').removeAttr('disabled');</script>");
        }
        private void llenar_tabla()
        {
            List<string> lista = dibujaItem();
            DataTable dt = getMedidor(lista);
            gv.DataSource = dt;
            gv.DataBind();
        }

        private List<string> dibujaItem()
        {
            List<string> listaLine = new List<string>();
            //Recorro array validando registros
            foreach (GridViewRow row in gv.Rows)
            {
                string cli = cliente.Text.ToString();
                string zon = zona.SelectedValue.ToString();
                string cod = codigos.SelectedValue.ToString();
                string ser = row.Cells[0].Text;
                string mar = row.Cells[1].Text;
                string mod = row.Cells[2].Text;

                listaLine.Add(cli + ";" + zon + ";" + cod + ";" + ser + ";" + mar + ";" + mod);
            }

            return listaLine;
        }
        /// Obtiene el data table de un archivo con extension .csv que se leyo previamente
        /// <param name="lista">Lista de datos del archivo csv</param>

        private DataTable getMedidor(List<string> lista)
        {
            DataTable dt = armandoColumnas();
            foreach (string item in lista)
            {
                string[] ListItems = item.Split(';');
                dt.Rows.Add(ListItems);
            }
            return dt;
        }
        /// Armando un data table para la carga de los archivos
        private DataTable armandoColumnas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre cliente");
            dt.Columns.Add("Zona");
            dt.Columns.Add("Codigo entrada");
            dt.Columns.Add("Serial medidor");
            dt.Columns.Add("Marca medidor");
            dt.Columns.Add("Modelo medidor");

            return dt;
        }

        protected void envia(object sender, EventArgs e)
        {
            ingresa_tarea();
        }

        protected void ingresa_tarea()
        {
            //Recorro array validando registros
            foreach (GridViewRow row in gv.Rows)
            {
                string cli = row.Cells[0].Text;
                string zon = row.Cells[1].Text;
                string cod = row.Cells[2].Text;
                string ser = row.Cells[3].Text;
                string mar = row.Cells[4].Text;
                string mod = row.Cells[5].Text;

                Tareas gt = new Tareas();                           //Crea una instancia de clase 
                string usu = Convert.ToString(Session["Login"]);    //Lee la variable Session
                gt.Usuario = usu;                                   //Pasa el valor de usuario
                string Cliente = gt.getIdCliente();                 //Pasa el metodo getId para validar si existe el usuario  
                gt.Cliente = Cliente;                               //Pasa el valor de la lista
                gt.Zona_texto = zon;                                //Pasa el texto de campo zona
                string id_zona = gt.getIdZona();                    //Consulta el ID de zona
                gt.Zona = id_zona;                                  //Pasa el ID de zona
                gt.Codigo_texto = cod;                              //Pasa el texto de campo codigos
                string id_codigo = gt.getIdCodigo();                //Consulta el ID de codigos
                gt.Codigo = id_codigo;                              //Pasa el ID de codigos
                string doc = gt.getCreateDocumento();
                Session["documento"] = doc;
                gt.Documento = gt.getCreateDocumento();             //Pasa el valor de la lista
                gt.Serial = ser;                                    //Pasa el valor del serial
                gt.Marca = mar;                                     //Pasa el valor de la marca
                gt.Modelo = mod;                                    //Pasa el valor del modelo
                Session["respuesta"] = gt.getGuardarTarea();                 //Toma el resultado del ingreso
            }
            if (Convert.ToString(Session["respuesta"]) == "")
            {
                Tareas gt = new Tareas();                           //Crea una instancia de clase 
                string usu = Convert.ToString(Session["Login"]);    //Lee la variable Session
                gt.Usuario = usu;                                   //Pasa el valor de usuario
                string Cliente = gt.getIdCliente();                 //Pasa el metodo getId para validar si existe el usuario
                gt.getIncrementaDocEntry();                         //Incrementa en uno el DOC-ENTRY
                gt.getRegistroOk();                                 //Registra en LOG el ok
                Response.Redirect("Registro.aspx");
            }
            else
            {
                /*
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#failModal').modal('show');</script>");
                /*Tareas gt = new Tareas();                           //Crea una instancia de clase 
                string usu = Convert.ToString(Session["Login"]);    //Lee la variable Session
                gt.Usuario = usu;                                   //Pasa el valor de usuario
                string Cliente = gt.getIdCliente();                 //Pasa el metodo getId para validar si existe el usuario
                gt.getIncrementaDocEntry();                         //Incrementa en uno el DOC-ENTRY
                gt.getRegistroFail();                                 //Registra en LOG el ok
                //Response.Redirect("Registro.aspx");*/
            }
        }
    }

}