using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        public IActionResult Comenzar()
        {
            int estadoJuego = Escape.GetEstadoJuego();
            return RedirectToAction("Habitacion", new { sala = estadoJuego });
        }

        [HttpGet]
        public IActionResult Habitacion(int sala)
        {
            if (sala != Escape.GetEstadoJuego())
                return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });

            ViewBag.Sala = sala;
            return View($"Habitacion{sala}");
        }

        [HttpPost]
        public IActionResult Habitacion(int sala, string clave)
        {
            if (sala != Escape.GetEstadoJuego())
                return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });

            if (!string.IsNullOrEmpty(clave))
            {
                if (Escape.ResolverSala(sala, clave))
                {
                    if (sala == 4)
                        return RedirectToAction("Victoria");

                    return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
                }
                ViewBag.Error = "Clave incorrecta. Intenta de nuevo.";
            }

            ViewBag.Sala = sala;
            return View($"Habitacion{sala}");
        }

        public IActionResult Victoria()
        {
            return View();
        }
    }