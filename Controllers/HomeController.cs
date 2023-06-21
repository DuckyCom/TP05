using Microsoft.AspNetCore.Mvc;
using TP05.Models;
namespace TP05.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        Escape.ReiniciarJuego();
        return View();
    }
    public IActionResult Creditos(){
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        ViewBag.Lore = Escape.Ganaste();
        return View();
    }
    public IActionResult Tutorial()
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        return View();
    }
    public IActionResult Comenzar()
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        //tiene que retornar la habitacion sin resolverse, ej: si el jugador se quedó en la 3 y le da a comenzar, que lo deje en la 3 🗣🗣🗣🗣
        if (Escape.DevolverIntentosFallidos() == 0) return View();
        else return View(Nivel());
    }
    public IActionResult Empezar(int sala, string usuario)
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        Escape.CambiarNombre(usuario);
        Escape.InicializarJuego();
        return View(Nivel());
    }
    public IActionResult Pepe2(string decision)
    {
        if (decision == "1")
        {
            return View("Papel");
        }
        else
        {
            return View("Acertijo");
        }
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        ViewBag.Nombre = Escape.GetNombre();
        ViewBag.KingNombre = Escape.GetElNombre();
        bool resuelto;
        if (sala != Escape.GetEstadoJuego()) return View(Nivel());
        resuelto = Escape.ResolverSala(sala, clave);
        if (resuelto && Escape.GetEstadoJuego() == 6)
        {
            Escape.Ganar();
            Escape.ReiniciarJuego();
            Escape.ReiniciarIntentos();
            return View("Creditos");
        }
        else if (resuelto)
        {
            Escape.ReiniciarIntentos();
            return View(Nivel());
        }
        else 
        {
            Escape.RestarIntento();
            if (Escape.DevolverIntentos() == 0) 
            {
                Escape.ReiniciarJuego();
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
    public IActionResult OpcionNivel5(string clave)
    {
        if (clave == "Rompecabezas")
        {
            return View(Nivel());
        }
        else return View("Escape");
    }
    public IActionResult Muerte(string usuario)
    {
        Escape.CambiarNombre(usuario);
        return View("Index");
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
