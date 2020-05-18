<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12 text-center">
            <h3>Creacion de tareas</h3>
        </div>
    </div>
     <div class="row">
        <div class="col-lg-12">
            <Label ID="medidores" runat="server" Class="etiquetas text-center">Cantidad medidores</Label>
        </div>
     </div>
     <div class="row">
        <div class="col-lg-12 text-center">
            <input type="text" id="cant_medidores" runat="server" Class="cajas" value="0" />
        </div>
     </div>
     <div class="row">
         <div class="col-lg-6 text-center">
            <button disabled type="button" ID="agregar_dispositivo" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModalLive">
                Agregar dispositivo
            </button>
         </div>
         <div class="col-lg-6 text-center">
            <button disabled type="button" runat="server" id="eliminar_dispositivo" class="btn btn-danger" data-toggle="modal" data-target="#eliminarModal">
                Eliminar dispositivo
            </button>
             <input type="hidden" id="elimina" value="0" runat="server"/>
             <input type="hidden" id="redirecciona" value="0" runat="server"/>
         </div>
     </div>
<div class="modal fade" id="exampleModalLive" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Informacion adicional</h5>
      </div>
      <div class="modal-body">
    <div class="row">
        <div class="col-lg-2">
            <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Marca medidor"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_Selected" AutoPostBack="true">
            </asp:DropDownList>
            <input type="hidden" value="0" runat="server" id="cambio_marca" />
        </div>
        <div class="col-lg-2">
            <asp:Label ID="Label4" class="etiquetas" runat="server" Text="Modelo medidor"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="modelo" class="cajas" runat="server" >
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:Label class="etiquetas" runat="server" Text="Zona"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="zona" class="cajas" runat="server" >
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-2">
            <asp:Label class="etiquetas" runat="server" Text="Codigo de ingreso"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="codigos" class="cajas" runat="server" >
            </asp:DropDownList>    
        </div>
        <div class="col-lg-4">
            <asp:Button ID="ayuda" runat="server" Text="Ayuda" class="btn btn-warning" Width="150px" OnClick="ayuda_Click"/>
        </div>
        <div class="col-lg-2">
            <asp:Label runat="server" class="etiquetas">Serial</asp:Label>
        </div>
        <div class="col-lg-2">
            <input size="10" class="cajas" type="text" ID="serial" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="error_marca" Width="100%" runat="server" CssClass="alert alert-danger" Visible="false">Campo "Marca" no puede ser vacio</asp:Label>
            <asp:Label ID="error_modelo" Width="100%" runat="server" CssClass="alert alert-danger" Visible="false">Campo "Modelo" no puede ser vacio</asp:Label>
            <asp:Label ID="error_zona" Width="100%" runat="server" CssClass="alert alert-danger" Visible="false">Campo "zona" no puede ser vacio</asp:Label>
            <asp:Label ID="error_codigo" Width="100%" runat="server" CssClass="alert alert-danger" Visible="false">Campo "Codigo" no puede ser vacio</asp:Label>
            <asp:Label ID="error_serial" Width="100%" runat="server" CssClass="alert alert-danger" Visible="false">Campo "Serial" no puede ser vacio</asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="6" Visible="False" >
           
                <Columns>
                    <asp:BoundField DataField="CODE" HeaderText="Codigo" />
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="Descripcion" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
      <div class="modal-footer">
        <asp:Button runat="server" Text="Cancelar" id="cancelar" class="btn btn-danger" Width="150px" data-dismiss="modal" OnClick="cancelar_click"></asp:Button>
        <asp:Button runat="server" Text="Aceptar" class="btn btn-success" Width="150px" onClick="continuar_Click"></asp:Button>
      </div>
    </div>
  
    </div>
    </div>
</div>
<!-- Modal -->
<div class="modal fade" id="eliminarModal" tabindex="-1" role="dialog" aria-labelledby="eliminarModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="eliminarModalLabel">Eliminar dispositivo</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body text-center">
        Esta operación eliminará el ultimo registro ingresado.<br />
        ¿Desea continuar?
      </div>
      <div class="modal-footer text-center">
        <asp:Button runat="server" Text="No" id="Button1" class="btn btn-danger" Width="150px" data-dismiss="modal"></asp:Button>
        <asp:Button runat="server" Text="Si" id="Button2" class="btn btn-success" Width="150px" onClick="eliminar_Click"></asp:Button>
      </div>
    </div>
  </div>
</div>
<!-- Modal -->
<div class="modal fade" id="failModal" tabindex="-1" role="dialog" aria-labelledby="failModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="failModalLabel">Registro correcto</h5>
      </div>
      <div class="modal-body">
        No ha sido posible salvar el listado de Medidores.<br />
        El Acta de Entrada con el que fue registrado el proceso es: <input runat="server" type="text" id="documento" />
      </div>
      <div class="modal-footer">
        <asp:button text="Continuar" class="btn btn-success" runat="server"></asp:button>
      </div>
    </div>
  </div>
</div>
    <div class="row">
        <div class="col-6 text-center">
        </div>
        <div class="col-6 text-center">
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div style="overflow:scroll;width:100%;height:300px;">        
                <asp:GridView ID="gv2" CssClass="tabla" runat="server" Height="300px">
                </asp:GridView>                
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Total medidores <asp:Label id="total_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="total" value="0" runat="server" />
            </div>
        </div>
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Listados <asp:Label id="listados_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="listados" value="0" runat="server" />
            </div>
        </div>
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Faltantes <asp:Label id="faltantes_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="faltantes" value="0" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 text-center">
            <input type="hidden" id="confirmado" value="0" runat="server" />
            <asp:Button ID="guardar" Enabled="false" runat="server" Text="Guardar" OnClick="envia" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>