<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DefinirGrupo.aspx.cs" Inherits="CapaPresentacion.DefinirGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12 text-center">
            <h3>Creacion de tareas</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label7" runat="server" Text="Cantidad/Documento"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Class="etiquetas" Text="Cantidad de medidores"></asp:Label>
            <asp:TextBox ID="cant_medidores" runat="server" Class="cajas" Enabled="False" OnTextChanged="cant_medidores_TextChanged">0</asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Class="etiquetas" Text="Documentos de entrada"></asp:Label>
            <asp:TextBox ID="doc_entrada" runat="server" Class="cajas" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="act_cantidad" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" OnClick="actualizar_Click" Enabled="False" />
            <br />
        </div>
        <div class="col-4">
            <asp:Label ID="Label8" runat="server" Text="Grupo"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Class="etiquetas" Text="Tipo de grupo"></asp:Label>
            <asp:DropDownList ID="tipoGrupo" runat="server" Enabled="False">
                <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                <asp:ListItem>Unico</asp:ListItem>
                <asp:ListItem>Individual</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="act_grupo" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" Enabled="False" />
            <br />
        </div>
        <div class="col-4">
            <asp:Label ID="Label9" runat="server" Text="Serial"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Class="etiquetas" Text="Cantidad de medidores"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Class="cajas">0</asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Class="etiquetas" Text="Documentos de entrada"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" Class="cajas"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="act_serial" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" Enabled="False" OnClick="act_serial_Click" />
            <br />
        </div>
    <div>
    <div ID="definicion" runat="server"></div>
<div class="modal fade" id="exampleModalLive" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Definir grupo</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
 <div class="row">
        <div class="col-12">
                <asp:Label runat="server">Definicion grupo</asp:Label>
    <br />
    <br />
    <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_SelectedIndexChanged" AutoPostBack="True" >
    </asp:DropDownList>
        <asp:Label ID="Label4" class="etiquetas" runat="server" Text="Modelo"></asp:Label>
    <asp:DropDownList ID="modelo" class="cajas" runat="server" OnSelectedIndexChanged="modelo_SelectedIndexChanged" OnClick="modelo_Click" >
    </asp:DropDownList>
        <asp:Label ID="Label10" class="etiquetas" runat="server" Text="Tipo de energia"></asp:Label>
    <asp:DropDownList ID="energia" class="cajas" runat="server" OnSelectedIndexChanged="energia_SelectedIndexChanged" >
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
        <asp:ListItem Value="1">Activa</asp:ListItem>
        <asp:ListItem Value="2">Reactiva</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label11" class="etiquetas" runat="server" Text="Fases/Hilos"></asp:Label>
    <asp:DropDownList ID="fase" class="cajas" runat="server" >
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
        <asp:ListItem Value="A">Fase 1 / Hilos 2</asp:ListItem>
        <asp:ListItem Value="B">Fase 1 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="C">Fase 2 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="D">Fase 3 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="E">Fase 3 / Hilos 4</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:HiddenField runat="server" ID="nombreGrupo" />
    <br />
    
    <asp:Button ID="cancelar" runat="server" Text="Cancelar"  class="btn btn-danger" Width="150px" OnClick="cancelar_Click" />
        </div>
    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
        <asp:Button runat="server" Text="Continuar"  class="btn btn-success" Width="150px" OnClick="continuar_Click" />
      </div>
    </div>
  </div>
</div>
    <div class="row">
        <div class="col-12">
            <h3>Creacion de tareas</h3>
            <asp:Table id="Table1" runat="server" CellPadding="10" 
                GridLines="Both"
                HorizontalAlign="Center" CssClass="mGRID">
                <asp:TableRow>
                    <asp:TableCell>
                        Documento de entrada
                    </asp:TableCell>
                    <asp:TableCell>
                        Grupo
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    
    </div>
        </div>
</asp:Content>
