<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Archivo.aspx.cs" Inherits="CapaPresentacion.Archivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    <form id="form1">
    <div class="text-center">
    
        <asp:FileUpload ID="fuPrueba" Class="btn btn-info" runat="server" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnProcesar" Class="btn btn-success" runat="server" OnClick="btnProcesar_Click" Text="Procesar" />
&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Text="esto es un caso de prueba :)" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:GridView ID="gv" runat="server" CssClass="tabla">
        </asp:GridView>
        <asp:Button ID="guardar_archivo" Enabled="false" runat="server" Text="Guardar" OnClick="envia" CssClass="btn btn-success" />

        <br />
    </div>
<!-- Modal -->
<div class="modal fade" id="blancoModal" tabindex="-1" role="dialog" aria-labelledby="blancoModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="blancoModalLabel">Archivo con valores vacios</h5>
      </div>
      <div class="modal-body">
        El archivo contiene valores vacios, rectifique archivo.
      </div>
      <div class="modal-footer">
        <asp:Button runat="server" Text="Continuar" id="Button2" class="btn btn-success" Width="150px" OnClick="limpiar_tabla"></asp:Button>
      </div>
    </div>
  </div>
</div>
<!-- Modal -->
<div class="modal fade" id="camposModal" tabindex="-1" role="dialog" aria-labelledby="camposModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="camposModalLabel">Informacion adicional</h5>
      </div>
      <div class="modal-body">
        <asp:Label class="etiquetas" runat="server" Text="Zona"></asp:Label>
        <asp:DropDownList ID="zona" class="cajas" runat="server" >
        </asp:DropDownList>
        <asp:Label class="etiquetas" runat="server" Text="Codigos de error"></asp:Label>
        <asp:DropDownList ID="codigos" class="cajas" runat="server" >
        </asp:DropDownList>
      </div>
      <div class="modal-footer">
        <asp:Button runat="server" Text="Continuar" id="Button1" class="btn btn-success" Width="150px" OnClick="completar_tabla"></asp:Button>
      </div>
    </div>
  </div>
</div>
    </form>
</asp:Content>