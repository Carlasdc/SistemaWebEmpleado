using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;

        public EmpleadoController(EmpleadoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SideBar = "Administracion de Empleados";
            return View("Index", _context.Empleados.ToList());
        }

        public IActionResult Create()
        {
              Empleado empleado = new Empleado();
              return View("Create", empleado);
            
        }

        // POST: /Empleado/Create
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", empleado);
            }

        }

        [HttpGet("/empleado/ListarPorTitulo/{titulo}")]
        // GET: /empleado/ListarPorTitulo/manager
        public IActionResult ListarPorTitulo(string titulo)
        {
            List<Empleado> lista = (from p in _context.Empleados
                                  where p.Titulo == titulo
                                  select p).ToList();
            return View("Index", lista);
        }
        public IActionResult Delete(int id)
        {
            var empleado = _context.Empleados.SingleOrDefault(m => m.Id == id);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Empleado empleado = _context.Empleados.Find(id);

            return View("Edit", empleado);

        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {

            if (ModelState.IsValid)
            {

                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);

        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Detail", empleado);
        }
    }
}
