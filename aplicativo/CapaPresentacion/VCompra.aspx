<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VCompra.aspx.cs" Inherits="CapaPresentacion.Vistas.VCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="well well-sm">
                <form class="form-horizontal" method="post">
                    <fieldset>
                        <legend class="text-center header">Registrar Compra</legend>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"></span>
                            <div class="col-md-8">
                                <input id="identificacion" name="name" type="text" placeholder="Codigo Compra" class="form-control">
                                   </div>
                            <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"></span>
                            <div class="col-md-8">
                                <input id="fname" name="name" type="text" placeholder="Fecha Compra" class="form-control">
                            </div>
                                  
                            <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"></span>
                            <div class="col-md-8">
                                <input id="phone" name="phone" type="text" placeholder="Total" class="form-control">
                            </div>
                         </div>

                        <div class="form-group">
                            <span class="col-md-1 col-md-offset-2 text-center"></span>
                            <div class="col-md-8">
                                <input id="email" name="email" type="text" placeholder="Nit Proveedor" class="form-control">
                            </div>
                        </div>

                        
                                               
                        <div class="form-group">
                            <div class="col-md-12 text-center">
                                <button type="submit" class="btn btn-primary btn-lg">Registrar</button>
                                <a class="nav-link" href="Site1.Master">
                              </a>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</div>
</asp:Content>
