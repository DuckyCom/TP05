using Microsoft.AspNetCore.Mvc;
using TP05.Models;
namespace TP05.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        return View();
    }
    public IActionResult Creditos(){
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        return View();
    }
    public IActionResult Tutorial()
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        return View();
    }
    public IActionResult Comenzar(string usuario)
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        //tiene que retornar la habitacion sin resolverse, ej: si el jugador se quedó en la 3 y le da a comenzar, que lo deje en la 3 🗣🗣🗣🗣
        Escape.CambiarNombre(usuario);
        return View();
    }
    public IActionResult Empezar(int sala)
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        Escape.InicializarJuego();
        return View(Nivel());
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
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
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        if (sala == "EndingConquistador") Escape.CambiarElNombre();
        return View();
    }
    public IActionResult Pepe()
    {
        return View();
    }
    static string Nivel()
    {
        return "Nivel" + Escape.GetEstadoJuego();
    }
    public IActionResult PreguntasNivel3(int respuestasCorrectas){
        
        if (respuestasCorrectas > 5) return RedirectToAction("Habitacion", "Home", 3, "Resuelto");
        else return RedirectToAction("Habitacion", "Home", 3, "Bobo");
    }
}
