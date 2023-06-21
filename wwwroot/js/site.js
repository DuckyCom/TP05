window.onload = function() {
  var sala = document.getElementById('sala')
  var temporizador = document.getElementById('temporizador');

  if (sala == 1) 
  {
  var minutos = 30;
  var segundos = 0;
  }
  

  setInterval(actualizarTemporizador, 1000);

  function actualizarTemporizador() {
    if (segundos > 0) {
      segundos--;
    } else {
      if (minutos > 0) {
        minutos--;
        segundos = 59;
      } else {
        // El temporizador ha llegado a 0, puedes agregar aquí alguna lógica adicional
        // o redirigir a otra página si es necesario.
      }
    }

    temporizador.textContent = pad(minutos) + ':' + pad(segundos);
  }

  function pad(valor) {
    return valor < 10 ? '0' + valor : valor;
  }
};
function prueba(){
  var preguntasTrivia = [];
  preguntasTrivia[0] = "goku"; //respuesta: Goku.
  preguntasTrivia[1] = "duende verde"; //respuesta: Duende Verde.
  preguntasTrivia[2] =  document.getElementById("nombre").value; //respuesta: el nombre que eligió el jugador al principio del juego (en el comienzo).
  preguntasTrivia[3] = "5"; //Respuesta correcta: 4. Si elige 1, 2, 3 o 5 está mal.
  preguntasTrivia[4] = "que robaron los españoles"; //en esta se le da la respuesta. El jugador tiene que elegir la pregunta correcta. Pregunta correcta: ¿Qué robaron los españoles?
  preguntasTrivia[5] = "piedra"; //respuesta: Piedra (piedra papel o tijeras).
  var contador = 0;
  for(let i = 0; i < 5; i++)
  {
    if (preguntasTrivia[i] == document.getElementById("clave" + i.toString()).value)
    {
      contador+=1;
    }
  }
  if (contador >= 4)
  {
    document.getElementById("clave").value="Resuelto";
  }
  document.forms[0].submit();
};