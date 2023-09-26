using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXU1_GONZALEZ.Models;

namespace EXU1_GONZALEZ.Controllers
{
    public class FechaController : Controller
    {
        // GET: Fecha
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalcularDiferenciaFechas()
        {
            // Obtiene la fecha actual del sistema
            DateTime fechaActual = DateTime.Now;

            return View();
        }

        [HttpPost]
        public ActionResult CalcularDiferenciaFechas(string fechaUsuarioStr)
        {
            if (!string.IsNullOrWhiteSpace(fechaUsuarioStr))
            {
                // Intenta convertir la entrada del usuario en un objeto DateTime
                if (DateTime.TryParseExact(fechaUsuarioStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaUsuario))
                {
                    // Calcula la diferencia entre las dos fechas
                    TimeSpan diferencia = fechaUsuario - DateTime.Now;

                    // Puedes pasar la diferencia a la vista para mostrarla
                    ViewBag.DiferenciaDias = diferencia.Days;
                }
                else
                {
                    ViewBag.Error = "La fecha ingresada no es válida. Asegúrese de usar el formato dd/MM/yyyy.";
                }
            }

            return View();
        }
    }
}