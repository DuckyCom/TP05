using Microsoft.AspNetCore.Mvc;
using TP05.Models;
namespace TP05.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult creditos(){
        return View("creditos");
    }
    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Comenzar()
    {
        //tiene que retornar la habitacion sin resolverse, ej: si el jugador se quedó en la 3 y le da a comenzar, que lo deje en la 3 🗣🗣🗣🗣
        return View(Nivel());
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        bool resuelto;
        if (sala != Escape.GetEstadoJuego()) return View(Nivel());
        resuelto = Escape.ResolverSala(sala, clave);
        if (resuelto) return View(Nivel());
        else return View("Muerte");
    }
    //faltaria  un IActionResult de Habitacion pero no entendi bien como hacerlo xd
    static string Nivel()
    {
        return "Nivel" + Escape.GetEstadoJuego();
    }
}
