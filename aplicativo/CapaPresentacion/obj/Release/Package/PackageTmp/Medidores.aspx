<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Medidores.aspx.cs" Inherits="CapaPresentacion.Medidores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:Label runat="server">Nombre del grupo</asp:Label>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label class="etiquetas" runat="server" Text="Zona"></asp:Label>
            <asp:DropDownList ID="zona" class="cajas" runat="server" OnSelectedIndexChanged="zona_SelectedIndexChanged" >
            </asp:DropDownList>
            <asp:Label class="etiquetas" runat="server" Text="Codigos de error"></asp:Label>
            <asp:DropDownList ID="codigos" class="cajas" runat="server" >
            </asp:DropDownList>
            <br />
            <asp:Button ID="continuar" runat="server" Text="Continuar"  class="btn btn-success" Width="150px" OnClick="continuar_Click" />
            <asp:Button ID="cancelar" runat="server" Text="Cancelar"  class="btn btn-danger" Width="150px" OnClick="cancelar_Click" />
            <asp:Button ID="ayuda" runat="server" Text="Ayuda" class="btn btn-warning" Width="150px" OnClick="ayuda_Click"/>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="6" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False" >
        <Columns>
            <asp:BoundField DataField="CODE" HeaderText="Codigo" />
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Descripcion" />
        </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
