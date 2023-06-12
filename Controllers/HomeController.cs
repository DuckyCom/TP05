using Microsoft.AspNetCore.Mvc;
using TP05.Models;
namespace TP05.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Creditos(){
        return View();
    }
    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Comenzar(string usuario)
    {
        //tiene que retornar la habitacion sin resolverse, ej: si el jugador se quedó en la 3 y le da a comenzar, que lo deje en la 3 🗣🗣🗣🗣
        Escape.CambiarNombre(usuario);
        return View();
    }
    public IActionResult Empezar(int sala)
    {
        Escape.InicializarJuego();
        return View(Nivel());
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        ViewBag.Nombre = Escape.GetNombre();
        bool resuelto;
        if (sala != Escape.GetEstadoJuego()) return View(Nivel());
        resuelto = Escape.ResolverSala(sala, clave);
        if (resuelto) return View(Nivel());
        else 
        {
            Escape.RestarIntento();
            if (Escape.DevolverIntentos() == 0) 
            {
                Escape.ReiniciarIntentos();
                return View("Muerte");
            }
            else return View(Nivel());
        } 
    }
    public IActionResult EndingConquistador(string sala)
    {
        if (sala == "EndingConquistador") Escape.CambiarElNombre();
        return View();
    }
    //faltaria  un IActionResult de Habitacion pero no entendi bien como hacerlo xd
    static string Nivel()
    {
        return "Nivel" + Escape.GetEstadoJuego();
    }
    
}
