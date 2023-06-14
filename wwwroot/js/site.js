window.onload = function() {
  var temporizador = document.getElementById('temporizador');
  var minutos = 30;
  var segundos = 0;

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