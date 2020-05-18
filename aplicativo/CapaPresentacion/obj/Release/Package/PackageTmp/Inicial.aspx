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
        <asp:Label ID="Fec_ini" class="etiquetas" runat="server" Text="Inicial"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" class="cajas" OnTextChanged="TextBox1_TextChanged" TextMode="Date"></asp:TextBox>
    
        <asp:Label ID="Fec_fin" class="etiquetas" runat="server" Text="Final"></asp:Label>

    
        <asp:TextBox ID="TextBox2" runat="server" class="cajas" TextMode="Date"></asp:TextBox>

        <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Doc. Entrada"></asp:Label>

    
    <asp:DropDownList ID="docEntrada" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>
        </div>
        </div>
    <br />
    <div class="row">
        <div class="col-12">
        <asp:Label ID="Num_Ser" class="etiquetas" runat="server" Text="Num serial"></asp:Label>

    
    <asp:DropDownList ID="numeroSerial" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

        <asp:Label ID="Nom_Gru" class="etiquetas" runat="server" Text="Grupo"></asp:Label>

    
    <asp:DropDownList ID="nombreGrupo" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

        <asp:Label ID="Esta_Acti" runat="server" class="etiquetas" Text="Estado"></asp:Label>

    <asp:DropDownList ID="estadoActividad" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>               
        <asp:ListItem Value="0">Precarga</asp:ListItem>
                       <asp:ListItem Value="1">Alistamiento inicial</asp:ListItem>
                       <asp:ListItem Value="5">Operacion en mesas</asp:ListItem>
                       <asp:ListItem Value="9">Revision de certificado</asp:ListItem>
                       <asp:ListItem Value="11">Etapa de salida</asp:ListItem>
                       <asp:ListItem Value="12">En tramite</asp:ListItem>
                       <asp:ListItem Value="16">Rechazo de recepcion</asp:ListItem>
                       <asp:ListItem Value="2">No recibido en sitio</asp:ListItem>
          </asp:DropDownList>
    
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
        AllowPagging="True"
    >
        <Columns>
            <asp:BoundField DataField="DOC_ENTRY" HeaderText="Documento Entrada" />
            <asp:BoundField DataField="NUM_SERIAL" HeaderText="Numero de serial" />
            <asp:BoundField DataField="NAME_GROUP" HeaderText="Nombre del grupo" />
            <asp:BoundField DataField="DATE_ENTRY" HeaderText="Fecha de ingreso" />
            <asp:BoundField DataField="ID_STATE" HeaderText="Estado actual" />
        </Columns>

    </asp:GridView>

            <div>
        </div>
</asp:Content>
