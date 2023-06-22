namespace TP05.Models;
public static class Escape
{
    static string[] incognitasSalas = new string[6];
    static string[] nombresGenericos = new String[10];

    static int vecesGanadas = 0;
    static int estadoJuego = 0;
    static int intentosFallidos = 0;
    static int intentosRestantes = 3;
    static string elNombre = "Manu";
    static string Nombre;

    public static string GetNombre()
    {
        return Nombre;
    }
    public static string GetElNombre()
    {
        return elNombre;
    }
    public static void RestarIntento()
    {
        intentosRestantes--;
    }
    public static void Ganar()
    {
        vecesGanadas++;
    }
    public static int Ganaste()
    {
        return vecesGanadas;
    }
    public static int DevolverIntentos()
    {
        return intentosRestantes;
    }
    public static int DevolverIntentosFallidos()
    {
        return intentosFallidos;
    }
    public static void ReiniciarIntentos()
    {
        intentosRestantes = 3;
    }
    public static void CambiarNombre(string usuario)
    {
        Nombre = usuario;
    }
    public static void CambiarElNombre()
    {
        elNombre = Nombre;
    }
    public static void InicializarJuego()
    {
        nombresGenericos[0] = "Jefferson";
        nombresGenericos[1] = "David";
        nombresGenericos[2] = "Rudolf";
        nombresGenericos[3] = "Eric";
        nombresGenericos[4] = "Raymond";
        nombresGenericos[5] = "Olaf";
        nombresGenericos[6] = "Muhammed";
        nombresGenericos[7] = "Ezequiel"; //Teacher reference
        nombresGenericos[8] = "rimpe";
        nombresGenericos[9] = "William";
        incognitasSalas[0] = "Mapa";
        incognitasSalas[1] = "3"; //aca el usuario va a elegir tipo formulario y dependiendo lo que diga resuelve (elige la primera puerta == '1', elige la segunda == '2' , elige la tercera == '3')
        incognitasSalas[2] = "0-20,6"; //(este el de las inyecciones, capaz que solo encuentre un y=0? ej: de {-43;1,6666666} que ponga el -43)
        incognitasSalas[3] = "Resuelto"; //esta sala son de varias preguntas, ¿capaz un if respuestas correctas mayor a 60% = 1 else = 0? SI ESTA BIEN QUE DEVUELVA RESUELTO LISTO
        incognitasSalas[4] = "Obama"; //aca no tenemos una respuesta todavia, pero es la del texto invisible
        incognitasSalas[5] = "bmpipnpsb"; //es alohomora de harry porter pero en cesar. 
    }
    public static void ReiniciarJuego()
    {
        estadoJuego = 0;
        intentosRestantes = 3;
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int sala, string incognita)
    {
        bool retornar;
        if (incognita == null) incognita="";
        if (incognitasSalas[sala].ToUpper() == incognita.ToUpper())
        {
            retornar = true;
            intentosRestantes = 3;
            estadoJuego++;
        }
        else
        {
            retornar = false;
            intentosFallidos++;
        }
        return retornar;
    }
}
