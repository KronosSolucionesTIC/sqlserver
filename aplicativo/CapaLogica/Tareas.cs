using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Tareas : TareasDAO
    {
        //atributos o campos 
        private string cliente; 
        private string zona;
        private string codigo;
        private string documento;
        private string serial;
        private string marca;
        private string modelo;
        private string usuario;
        private string zona_texto;
        private string codigo_texto;

        //metodos get y set 
        public string Cliente
        {
            get
            { return cliente; }
            set
            { cliente = value; }
        }

        public string Zona
        {
            get
            { return zona; }
            set
            { zona = value; }
        }

        public string Codigo
        {
            get
            { return codigo; }
            set
            { codigo = value; }
        }

        public string Documento
        {
            get
            { return documento; }
            set
            { documento = value; }
        }

        public string Serial
        {
            get
            { return serial; }
            set
            { serial = value; }
        }

        public string Marca
        {
            get
            { return marca; }
            set
            { marca = value; }
        }

        public string Modelo
        {
            get
            { return modelo; }
            set
            { modelo = value; }
        }

        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        public string Zona_texto
        {
            get
            { return zona_texto; }
            set
            { zona_texto = value; }
        }

        public string Codigo_texto
        {
            get
            { return codigo_texto; }
            set
            { codigo_texto = value; }
        }

        //Metodo para guardar la tarea
        public string getGuardarTarea()
        {
            DateTime fecha = DateTime.Now;
            string ok = SP_guardar_tarea(this.cliente,this.zona,this.codigo,this.documento,this.serial,this.marca,this.modelo,fecha);
            return ok;
        }

        //Metodo para retornar el ID del cliente
        public string getIdCliente()
        {
            string Cli = SP_id_cliente(this.usuario);
            return Cli;
        }

        //Metodo para retornar el ID de la zona
        public string getIdZona()
        {
            string Zon = SP_id_zona(this.zona_texto);
            return Zon;
        }

        //Metodo para retornar el ID del codigo de entrada
        public string getIdCodigo()
        {
            string Cod = SP_id_codigo(this.codigo_texto);
            return Cod;
        }
        //Metodo para incrementar en 1 el DOC_ENTRY
        public string getIncrementaDocEntry()
        {
            string Id = SP_incrementa_documento();
            return Id;
        }

        //Metodo para guardar en el log de registro ok
        public string getRegistroOk()
        {
            DateTime fecha = DateTime.Now;
            string cli = getIdCliente();
            string ok = SP_registro_ok(cli, fecha);
            return ok;
        }

        //Metodo para guardar en el log de registro FAIL
        public string getRegistroFail()
        {
            DateTime fecha = DateTime.Now;
            string error = "prueba";
            string cli = getIdCliente();
            string ok = SP_registro_fail(cli, fecha, error);
            return ok;
        }

        //Metodo para consultar el DOC_ENTRY
        public string getCreateDocumento()
        {
            string Doc = SP_create_documento();
            return Doc;
        }
        
    }

}
