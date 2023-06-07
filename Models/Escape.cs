namespace TP05.Models;
public static class Escape
{
    static string[] incognitasSalas;
    static int estadoJuego = 1;
    static int intentosFallidos = 0;

    static string elNombre = "Manu";

    static string Nombre;

    public static string GetNombre()
    {
        return Nombre;
    }
    public static void CambiarNombre(string usuario)
    {
        Nombre = usuario;
    }
    public static void CambiarElNombre()
    {
        elNombre = Nombre;
    }
    private static void InicializarJuego()
    {
        incognitasSalas[0] = "Mapa";
        incognitasSalas[1] = "3"; //aca el usuario va a elegir tipo formulario y dependiendo lo que diga resuelve (elige la primera puerta == '1', elige la segunda == '2' , elige la tercera == '3')
        incognitasSalas[2] = ""; //blud is not working🗣🗣💯💯/DAMEDA👹👹👹 (este el de las inyecciones, capaz que solo encuentre un y=0? ej: de {-43;1,6666666} que ponga el -43)
        incognitasSalas[3] = "Resuelto"; //esta sala son de varias preguntas, ¿capaz un if respuestas correctas mayor a 60% = 1 else = 0? SI ESTA BIEN QUE DEVUELVA RESUELTO LISTO
        incognitasSalas[4] = ""; //aca no tenemos una respuesta todavia, pero es la de el texto invisible
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int sala, string incognita)
    {
        bool retornar;
        if (incognitasSalas[sala] == incognita)
        {
            retornar = true;
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
