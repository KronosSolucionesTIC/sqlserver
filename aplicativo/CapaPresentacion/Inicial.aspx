<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
    <div class="col-12">
        </div>
        </div>
    <br />
    <div class="row">
        <div class="col-12">

    </div>
    </div>
    <br />

    
    <br />

    <div class="align-items-md-center">
        <asp:Button ID="actualizar" runat="server" Text="Buscar" class="btn btn-success" Width="150px" OnClick="actualizar_Click"/>
        <asp:Button ID="exportar" runat="server" Text="Exportar" class="btn btn-info" Width="150px" OnClick="exportar_click"/>
        <br />        
    </div>

    <asp:SqlDataSource ID="tareas" runat="server">

    </asp:SqlDataSource>

    <asp:GridView 
        ID="GridView1" 
        runat="server"
        CssClass="tabla" 
        AutoGenerateColumns="false"
        AllowPagging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
    >
        <Columns>
            <asp:BoundField DataField="NIT" HeaderText="NIT" />
            <asp:BoundField DataField="TIPO_CLIENTE" HeaderText="Tipo cliente" />
            <asp:BoundField DataField="NOMBRE_CLIENTE" HeaderText="Nombre" />
            <asp:BoundField DataField="CIUDAD_CLIENTE" HeaderText="Ciudad cliente" />
            <asp:BoundField DataField="DIRECCION_CLIENTE" HeaderText="Dirección cliente" />
            <asp:BoundField DataField="TELEFONO_CLIENTE" HeaderText="Telefono cliente" />
            <asp:BoundField DataField="NOMBRE_ALMACEN" HeaderText="Almacen" />
            <asp:BoundField DataField="CIUDAD_ALMACEN" HeaderText="Ciudad almacen" />
            <asp:BoundField DataField="NOMBRE_GPS" HeaderText="GPS" />
            <asp:BoundField DataField="PRECIO_GPS" HeaderText="Precio" />
            <asp:BoundField DataField="TIPO_GPS" HeaderText="Tipo" />
        </Columns>

    </asp:GridView>

            <div>
        </div>
</asp:Content>
