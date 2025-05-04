using Negocios2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Negocios2024.Controllers
{
    public class SolicitudController : Controller
    {
        private SolicitudServiceImpl solImp = new SolicitudServiceImpl();
        // GET: Solicitud
        public ActionResult Index()
        {
            IEnumerable<Solicitud> solicitudes = solImp.ListarSolicitudes();
            IEnumerable<Empleado> empleados = solImp.ListarEmpleados();

            ViewBag.Empleados = empleados;

            return View(solicitudes);
        }

        public ActionResult Empleados()
        {
            IEnumerable<Empleado> lista = new List<Empleado>();
            lista = solImp.ListarEmpleados();
            return View(lista);
        }
        public ActionResult Consultar(int id)
        {
            IEnumerable<Solicitud> lista = solImp.ConsultarPorEmpleado(id);
            ViewBag.Empleados = solImp.ListarEmpleados();
            return View("Index", lista);
        }

        //Crear
        public ActionResult Crear()
        {
            IEnumerable<Empleado> lista = solImp.ListarEmpleados();
            ViewBag.cboemp = new SelectList(lista, "idempleado", "apeempleado");
            return View(new Solicitud());
        }

        // POST: Crear
        [HttpPost]
        public ActionResult Crear(Solicitud sol)
        {

            bool existe = solImp.InsertarSolicitud(sol);
            if (existe)
            {
                return RedirectToAction("Index");
            }
            return View(sol);



        }
    }
}