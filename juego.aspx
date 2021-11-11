<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="juego.aspx.cs" Inherits="Mathkids.juego" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:label ID="lblcuentaID" runat="server" />
    
    <div class="container">
		<div id="pantalla-inicio">
			<h1> Math Kids</h1>
			
			<button class="boton" onclick="jugar(); return false;">JUGAR</button>
		</div>

		<div id="pantalla-juego">
			<h1 id="texto">MEMORIZA LA SECUENCIA</h1>
			<h2 id="resultado"> </h2>
			<div class="fila">
				<span class="num" onclick="comparar(this); return false;">0</span>
				<span class="num" onclick="comparar(this); return false;">1</span>
				<span class="num" onclick="comparar(this); return false;">2</span>
			</div>
			<div class="fila">
				<span class="num" onclick="comparar(this); return false;">3</span>
				<span class="num" onclick="comparar(this); return false;">4</span>
				<span class="num" onclick="comparar(this); return false;">5</span>
			</div>
			<div class="fila">
				<span class="num" onclick="comparar(this); return false;">6</span>
				<span class="num" onclick="comparar(this); return false;">7</span>
				<span class="num" onclick="comparar(this); return false;">8</span>
			</div>
			<div class="fila">
				<span class="num" onclick="comparar(this); return false;">9</span>
			</div>		
		</div>
		
		<div id="pantalla-fin">
			<p>Memorisaste <span id="digitos"> 8 </span>Dígitos</p>
			<button class="boton" onclick="jugar(); return false;"> INTENTAR NUEVAMENTE </button>
		</div>
	</div>

	<script type="text/javascript" src="Scripts/script.js"></script>  
</asp:Content>