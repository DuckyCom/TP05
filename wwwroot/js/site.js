window.onload = function() {
    var temporizador = document.getElementById('temporizador');
    var segundos = 0;
    var minutos = 0;
    var horas = 0;
  
    setInterval(actualizarTemporizador, 1000);
  
    function actualizarTemporizador() {
      segundos++;
  
      if (segundos >= 60) {
        segundos = 0;
        minutos++;
  
        if (minutos >= 60) {
          minutos = 0;
          horas++;
        }
      }
  
      temporizador.textContent = pad(horas) + ':' + pad(minutos) + ':' + pad(segundos);
    }
  
    function pad(valor) {
      return valor < 10 ? '0' + valor : valor;
    }
  };