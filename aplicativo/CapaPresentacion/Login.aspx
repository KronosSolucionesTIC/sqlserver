<%@ Page enableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>                       
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/select2/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="Estilo/css/main.css"/>
<!--===============================================================================================-->
    <title></title>
</head>
<body>
    <div class="limiter">
        <form id="form2" runat="server" class="login100-form validate-form">
        <div class="container-fluid" id="colordefondo2">
            <div class="container ">
                <div class="row">
                    <div class="col-md-12 col-xs-12 col-lg-4 mb-2 mt-2">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Estilo/images/ingresar_verde.png" OnClick="ImageButton1_Click1" />
                    </div>
                    <div class="col-md-12 col-xs-12 col-lg-8 pt-3">
                        <nav>
                            <p>
                                &nbsp;</p>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
<div class="container-login100" id="fondima">
    <div class="container">
        <div class="row">
            <div class="divLogin p-4 mb-4 mt-4 col-md-12 col-xs-12 col-lg-6" id="theDiv" runat="server">
                <div id="cajas">
                    <div class="pt-4 pb-3 pl-3 pr-3" id="bordes">

                            <div class="m-b-10">
					            <asp:Image ID="Image1" runat="server" ImageUrl="~/Estilo/images/log.png" Height="150px" Width="342px" />
					        </div>

					        <div class="wrap-input100 validate-input m-b-10" data-validate = "Username is required">
                                <asp:TextBox ID="Usuario" runat="server" class="input100" type="text" name="username" placeholder="Usuario"></asp:TextBox>
						        <span class="focus-input100"></span>
						        <span class="symbol-input100">
							       <i class="fa fa-user"></i>
						        </span>
					        </div>

					        <div class="wrap-input100 validate-input m-b-10" data-validate = "Password is required">
                                <asp:TextBox ID="Contraseña" runat="server" class="input100" type="password" name="pass" placeholder="Contraseña"></asp:TextBox>
						        <span class="focus-input100"></span>
						        <span class="symbol-input100">
							        <i class="fa fa-lock"></i>
						        </span>
					        </div>

					        <div class="container-login100-form-btn p-t-10">
                                <asp:Button ID="Iniciar" runat="server" class="login100-form-btn" OnClick="Iniciar_Click" />
							    <input type="hidden" value="0" id="con" runat="server"/>
					            <asp:HiddenField ID="TextoContador" runat="server" Value="0" />
							
					        </div>

				
                        </p>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>
</form>
</body>
</html>
