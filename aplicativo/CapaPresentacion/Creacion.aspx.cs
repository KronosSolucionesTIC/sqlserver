using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
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
                llenar_index();       //Llena la tabla inicial
                llenar_marca();       //Pasa funcion para llenar lista
                llenar_modelo();      //Pasa funcion para llenar lista
                llenar_zona();        //Pasa funcion para llenar lista
                llenar_codigos();     //Pasa funcion para llenar lista 
                llenar_ayuda();       //Pasa funcion para llenar lista
            }
            else {
                bool ok = ValidarCamposGrupo();
                if(ok == false)
                {
                    if(elimina.Value == "0")
                    {
                        if (redirecciona.Value == "0") {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#exampleModalLive').modal('show');</script>");
                        }
                    } 
                } else
                {
                    agrega_items();
                    confirmado.Value = "1";
                    cambio_marca.Value = "0";
                }
                bloquea_campos_cant();
            }
        }

        private void llenar_index()
        {
            List<string> lista = leerArchivoTxt();
            DataTable dt = getDataTableTxt(lista);
            gv2.DataSource = dt;
            gv2.DataBind();
        }

        private List<string> leerArchivoTxt()
        {
            int counter = 0;
            List<string> listaLine = new List<string>();

                for (int a=0; a<20; a++)
                {
                    listaLine.Add(";;;;;");
                    counter++;
                }

            return listaLine;
        }
        /// Obtiene el data table de un archivo con extension .csv que se leyo previamente
        /// <param name="lista">Lista de datos del archivo csv</param>

        private DataTable getDataTableTxt(List<string> lista)
        {
            DataTable dt = armandoColumnas();
            int cont = 0;
            foreach (string item in lista)
            {
                if (cont < 20)
                {
                    string[] ListItems = item.Split(';');
                    dt.Rows.Add(ListItems);
                }
                cont++;
            }
            return dt;
        }

        private void llenar_tabla()
        {
            List<string> lista = dibujaItem();
            DataTable dt = getMedidor(lista);
            gv2.DataSource = dt;
            gv2.DataBind();
        }

        private List<string> dibujaItem()
        {
            List<string> listaLine = new List<string>();

            
            int lis = int.Parse(listados.Value.ToString());
            if (lis > 1)
            {
                //Recorro array validando registros
                foreach (GridViewRow row in gv2.Rows)
                {
                    string cli = row.Cells[0].Text;
                    string zon = row.Cells[1].Text;
                    string cod = row.Cells[2].Text;
                    string ser = row.Cells[3].Text;
                    string mar = row.Cells[4].Text;
                    string mod = row.Cells[5].Text;

                    listaLine.Add(cli + ";" + zon + ";" + cod + ";" + ser + ";" + mar + ";" + mod);
                }
            }

            for (int a = 0; a < 1; a++)
            {
                string cli = cliente.Text.ToString();
                string zon = zona.SelectedValue.ToString();
                string cod = codigos.SelectedValue.ToString();
                string ser = serial.Value.ToString();
                string mar = marca.SelectedValue.ToString();
                string mod = modelo.SelectedValue.ToString();

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

        private DataTable getMedidorUltimo(List<string> lista)
        {
            DataTable dt = armandoColumnas();
            foreach (string item in lista)
            {
                string[] ListItems = item.Split(';');
                dt.Rows.Add(ListItems);
            }
            return dt;
        }

        private void llenar_tabla_ultimo()
        {
            int lis = int.Parse(listados.Value.ToString());
            if (lis == 1)
            {
                List<string> lista = leerArchivoTxt();
                DataTable dt = getDataTableTxt(lista);
                gv2.DataSource = dt;
                gv2.DataBind();
            } else
            {
                List<string> lista = dibujaItemUltimo();
                DataTable dt = getMedidorUltimo(lista);
                gv2.DataSource = dt;
                gv2.DataBind();
            }
        }

        private List<string> dibujaItemUltimo()
        {
            List<string> listaLine = new List<string>();

            int lis = int.Parse(listados.Value.ToString());
            if (lis > 0)
            {
                //Recorro array validando registros
                int count = 0;
                foreach (GridViewRow row in gv2.Rows)
                {
                    string cli = row.Cells[0].Text;
                    string zon = row.Cells[1].Text;
                    string cod = row.Cells[2].Text;
                    string ser = row.Cells[3].Text;
                    string mar = row.Cells[4].Text;
                    string mod = row.Cells[5].Text;

                    listaLine.Insert(count,cli + ";" + zon + ";" + cod + ";" + ser + ";" + mar + ";" + mod);
                    count++;
                }
            }

            int total = listaLine.Count;
            int index = total - 1;

            listaLine.RemoveAt(index);
            return listaLine;
        }
        /// Obtiene el data table de un archivo con extension .csv que se leyo previamente
        /// <param name="lista">Lista de datos del archivo csv</param>

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

        protected void cerrar_Click(object sender, EventArgs e)
        {
            /*int salida;
salida = Convert.ToInt32(logout.Value);//Toma el valor del contador
Response.Write("<script language=javascript> alert('Respuesta es " + salida + "'); </script>");*/
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DefinirGrupo.aspx"); //Direcciona a definicion de grupo
        }

        protected void ingresa_tarea()
        {
            confirmado.Value = "1";
            //Recorro array validando registros
            foreach (GridViewRow row in gv2.Rows)
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
            } else
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

        protected void llenar_marca()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            DataTable dt = dg.getMarca();   //Pasa el metodo consulta inicial
            //marca.AppendDataBoundItems = true;
            DataRow fila = dt.NewRow();
            fila["MARK"] = "Seleccione...";
            dt.Rows.InsertAt(fila, 0);
            marca.DataTextField = "MARK";     //Selecciona el campo a mostrar
            marca.DataValueField = "MARK";    //Selecciona el campo para el valor
            this.marca.DataSource = dt;            //Agrega al GridView el dataset
            marca.DataBind();
        }

        protected void bloquea_campos_cant()
        {
            cant_medidores.Disabled = true;     //Bloquea cantidad

            //act_cantidad.Enabled = false;       //Bloquea actualizar
        }

        protected void desbloquea_campos_grupo()
        {
            //act_grupo.Enabled = true;       //Desbloquea actualizar
        }

        protected void agrega_items()
        {
            suma_contadores();   //Calcula los valores de contadores
            llenar_tabla();  //Dibuja item
            limpia_campos(); //Limpia los campos
            verifica_total();
            Session["existencias"] = true;
            activa_agregar();
        }

        protected void limpia_campos()
        {
            zona.SelectedValue = "GLOBAL";
            serial.Value = "";
            marca.SelectedValue = "Seleccione...";
            modelo.SelectedValue = "Seleccione...";
            codigos.SelectedValue = "Seleccione...";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>document.getElementById('Contenido_confirmado').value = 0;</script>");
        }
        protected void verifica_total()
        {
            int tot = int.Parse(cant_medidores.Value.ToString());
            int list = int.Parse(listados.Value.ToString());
            if (list < tot)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>document.getElementById('agregar_dispositivo').disabled = false;</script>");
            }
        }

        protected void suma_contadores()
        {
            //Suma, resta, saldo de contadores de items
            int tot = int.Parse(cant_medidores.Value.ToString());
            int list = int.Parse(listados.Value.ToString());
            list = list + 1;
            int fal = tot - list;
            //Pone los valores en los campos
            string strTot = tot.ToString();
            string strList = list.ToString();
            string strFal = fal.ToString();
            total.Value = strTot;
            total_mask.Text = strTot;
            listados.Value = strList;
            listados_mask.Text = strList;
            faltantes.Value = strFal;
            faltantes_mask.Text = strFal;
        }

        protected void resta_contadores()
        {
            //Suma, resta, saldo de contadores de items
            int tot = int.Parse(cant_medidores.Value.ToString());
            int list = int.Parse(listados.Value.ToString());
            list = list - 1;
            int fal = tot - list;
            //Pone los valores en los campos
            string strTot = tot.ToString();
            string strList = list.ToString();
            string strFal = fal.ToString();
            total.Value = strTot;
            total_mask.Text = strTot;
            listados.Value = strList;
            listados_mask.Text = strList;
            faltantes.Value = strFal;
            faltantes_mask.Text = strFal;
        }

        public bool ValidarCampos()
        {
            if (this.cant_medidores.Value.Equals("0"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('La cantidad debe ser mayor a 0');</script>");
                return false;
            }
            return true;
        }

        protected void act_grupo_Click(object sender, EventArgs e)
        {
                int cant = int.Parse(cant_medidores.Value);      //Toma la cantidad de medidores
                //string tipo = tipoGrupo.SelectedItem.Value;    //Pasa el valor de la lista
                Session["cantidad"] = cant;                     //Asigna cantidad a variable Session
                //Session["tipo"] = tipo;                         //Asigna tipo a variable Session
                //Response.Redirect("DefinirGrupo.aspx");         //Redirecciona a Definicion grupo
        }

        protected void act_serial_Click(object sender, EventArgs e)
        {

        }

        protected void act_serial_Click1(object sender, EventArgs e)
        {

        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Creacion.aspx");//Redirecciona creacion tarea
        }

        protected void marca_Selected(object sender, EventArgs e)
        {
            cambio_marca.Value = "1";
            llenar_modelo();        //LLena modelo
        }

        protected void llenar_modelo()
        {
            Grupo dg = new Grupo();               //Crea una instancia de clase
            dg.Marca = marca.SelectedValue;  //Pasa el valor de la lista
            DataTable dt = dg.getModelo();        //Pasa el metodo consulta inicial
            modelo.Items.Clear();
            modelo.AppendDataBoundItems = true;
            modelo.Items.Add("Seleccione...");
            this.modelo.DataSource = dt;            //Agrega al GridView el dataset
            modelo.DataTextField = "NAME_MODEL";     //Selecciona el campo a mostrar
            modelo.DataValueField = "NAME_MODEL";    //Selecciona el campo para el valor
            modelo.DataBind();
        }

        public bool ValidarCamposGrupo()
        {
            if (cambio_marca.Value != "0")
            {
                if (this.marca.Text.Equals("Seleccione..."))
                {
                    error_marca.Visible = true;
                    return false;
                }
                else
                {
                    error_marca.Visible = false;
                }
                if (this.modelo.Text.Equals("Seleccione..."))
                {
                    error_modelo.Visible = true;
                    return false;
                }
                else
                {
                    error_modelo.Visible = false;
                }
                if (this.zona.Text.Equals("Seleccione..."))
                {
                    error_zona.Visible = true;
                    return false;
                }
                else
                {
                    error_zona.Visible = false;
                }
                if (this.codigos.Text.Equals("Seleccione..."))
                {
                    error_codigo.Visible = true;
                    return false;
                }
                else
                {
                    error_codigo.Visible = false;
                }
                if (this.serial.Value.Equals(""))
                {
                    error_serial.Visible = true;
                    return false;
                }
                else
                {
                    error_serial.Visible = false;
                }
                return true;
            }
            return false;
        }

        public bool ValidarCamposSerial()
        {
            if (this.serial.Value.Equals(""))
            {
                return false;
            }
            else if (this.zona.SelectedValue.Equals("Seleccione..."))
            {
                return false;
            }
            else if (this.codigos.SelectedValue.Equals("Seleccione..."))
            {
                return false;
            }
            return true;
        }

        protected void ayuda_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true)
            {
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
            }
        }

        protected void continuar_Click(object sender, EventArgs e)
        {
            
        }

        protected void asignaSerial(object sender, EventArgs e)
        {
            bool campo = ValidarCamposSerial();
            if (campo == true)
            {
                /*
                ok.Value = "1";    //Pone valor a campo ok
                bloquea_campos_cant();
                agrega_items();
                agrega_array();
                activa_agregar();*/
            } else
            {
                //error.Visible = true;
            }
        }

        protected void activa_agregar()
        {
            int falt = int.Parse(faltantes.Value);
            if (falt > 0)
            {
                agregar_dispositivo.Disabled = false;
            } else
            {
                agregar_dispositivo.Disabled = true;
            }
        }
        protected void agrega_array()
        {
            
        }

        protected void deshabilita_grupo()
        {
            //habilitar_grupo.Disabled = true;    //Deshabilita boton de habilitar grupo
        }



        protected void llenar_ayuda()
        {
            Medidor ayu = new Medidor();               //Crea una instancia de clase  
            DataTable dt = ayu.getAyuda();     //Pasa el metodo consulta inicial
            this.GridView1.DataSource = dt;             //Agrega al GridView el dataset
            GridView1.DataBind();
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Archivo.aspx");//Redirecciona cargue por archivo plano
        }

        protected void eliminar_Click(object sender, EventArgs e)
        {
            llenar_tabla_ultimo();  //Funcion para eliminar registro
            resta_contadores();     //Resta los contadores
            activa_agregar();
        }

        protected void envia(object sender, EventArgs e)
        {
            ingresa_tarea();
        }

        protected void cancelar_click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#Contenido_agregar_dispostivio').removeAttr('disabled');</script>");
            if(Convert.ToBoolean(Session["existencias"]) == false){
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#Contenido_cant_medidores').removeAttr('disabled');</script>");
            }
        }

        protected void eliminar_item(object sender, EventArgs e)
        {
            Session["eliminar"] = true;
        }
    }
}