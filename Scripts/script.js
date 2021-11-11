var secuencia = [];
var nuevoNum, i, intervalID;

var pantallaInicio = document.getElementById("pantalla-inicio");
var pantallaJuego = document.getElementById("pantalla-juego");
var pantallaFin = document.getElementById("pantalla-fin");

var texto = document.getElementById("texto");
var resultado = document.getElementById("resultado");
var teclado = document.getElementsByClassName("num");
var cantidad_digitos = document.getElementById("digitos");

function jugar(){
	pantallaInicio.style.display = "none";
	pantallaJuego.style.display = "block";
	pantallaFin.style.display = "none";

	secuencia = [];

	comenzar();
}

function comenzar(){

	//genero un número aleatorio y lo guardo en el arreglo
	nuevoNum = Math.round(Math.random()*9);
	secuencia.push(nuevoNum);


	texto.innerHTML = "NUMEROS PARES E IMPARES";
	resultado.innerHTML = "";

	//Muestro la secuencia de números en el arreglo
	i=0;
	//cada 1,3segundos muestro un nuevo numero de la secuencia
	intervalID = setInterval(mostrarSecuencia,1300);

}


function mostrarSecuencia(){
	//agrego la animación para el numero
	teclado[secuencia[i]].classList.add("show");

	setTimeout(limpiarShow,700);
	

	//compruebo si he llegado al final de la secuencia
	if(i==(secuencia.length-1)){//si llegue al final
		//detengo el timer
		clearInterval(intervalID);
		i=0;
		setTimeout(mensajeTuTurno, 1500);	
	} else{
		i++;
	}
}

function limpiarShow(){
	for(j=0; j<=9;j++){
		teclado[j].classList.remove("show");
	}
}

function mensajeTuTurno(){
	texto.innerHTML = "MEMORIZA LOS NUMEROS";
}


//funcion que compara el mumero presionado del usuario
function comparar(numSeleccionado){

	if(secuencia[i] == numSeleccionado.innerHTML){
		i++;
	} else { 
		resultado.innerHTML = "INCORRECTO";
		resultado.style.color = "#FF3333"
		setTimeout(mostrarPantallaFinal,2500);

	}

	
	if(i==secuencia.length){ 
		resultado.innerHTML = "CORRECTO!!";
		resultado.style.color = "#25C817";

		limpiarShow();

		
		setTimeout(comenzar,1000);
	}
}

function mostrarPantallaFinal(){
	pantallaInicio.style.display = "none";
	pantallaJuego.style.display = "none";
	cantidad_digitos.innerHTML = secuencia.length - 1;
	pantallaFin.style.display = "block";
}


































