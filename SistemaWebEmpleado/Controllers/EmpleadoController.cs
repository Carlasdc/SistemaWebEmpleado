using Microsoft.AspNetCore.Mvc;
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
            _context.Add(empleado);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/person/ListaPorTitulo/{titulo}")]
        // GET: /person/ListaPorTitulo/manager
        public IActionResult ListaPorTitulo(string titulo)
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


    }
}
