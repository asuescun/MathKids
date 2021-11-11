<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mathkids._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <!--<asp:Label runat="server" Text="Usuario:" />
    <asp:TextBox runat="server" ID="txbUsuario" />
    <asp:Label runat="server" Text="Password:" />
    <asp:TextBox runat="server" ID="txbPassword" />
    <asp:Button runat="server" OnClick="login" Text="Login" />-->

    <div id="contenedor">            
        <div id="contenedorcentrado">
            <div id="login">
                <div id="loginform">
                    <label for="usuario">Usuario</label>
                    <input runat="server" id="usuario" type="text" name="usuario" required>
                        
                    <label for="password">Contraseña</label>
                    <input runat="server" id="password" type="password" name="password" required>
                        
                    <asp:Button CssClass="btnLogin" runat="server" Text="Ingresar" OnClick="login"/>
                    <asp:Label runat="server" ID="lblerror" />
                </div>
            </div>
            <div id="derecho">
                <div class="shadow10">
                    Bienvenido Maths Kids 
                </div>
                <hr>
                <div class="pie-form">
                    <a href="#">¿Perdiste tu contraseña?</a>
     
                    <hr>
                    <a href="#">« Volver</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
