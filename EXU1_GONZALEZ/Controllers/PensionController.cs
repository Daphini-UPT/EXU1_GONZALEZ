using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXU1_GONZALEZ.Models;

namespace EXU1_GONZALEZ.Controllers
{
    public class PensionController : Controller
    {
        // GET: Pension

        // Array de pensiones
        private static double[] Pensión = { 550, 500, 460, 400 };
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Process(int categoria, double promedio, int cuotasPagadas)
        {
            // Calculamos el descuento total
            double descuentoTotal = CalcularDescuento(categoria, promedio, cuotasPagadas);

            // Creamos el modelo de vista
            PensionViewModel model = new PensionViewModel();
            model.Descuento = descuentoTotal;
            model.NuevaPensión = (1 - descuentoTotal) * Pensión[categoria];

            return View(model);
        }

        private static double CalcularDescuento(int categoria, double promedio, int cuotasPagadas)
        {
            // Calculamos el descuento por promedio
            double descuentoPromedio = 0;
            if (promedio >= 18)
            {
                descuentoPromedio = 0.15;
            }
            else if (promedio >= 16)
            {
                descuentoPromedio = 0.12;
            }
            else if (promedio >= 14)
            {
                descuentoPromedio = 0.10;
            }

            // Calculamos el descuento por cuotas pagadas
            double descuentoCuotas = 0;
            if (cuotasPagadas == 5)
            {
                descuentoCuotas = 0.10;
            }
            else if (cuotasPagadas == 4)
            {
                descuentoCuotas = 0.09;
            }
            else if (cuotasPagadas == 3)
            {
                descuentoCuotas = 0.08;
            }

            // Calculamos el descuento total
            double descuentoTotal = descuentoPromedio + descuentoCuotas;

            return descuentoTotal;
        }

    }
}