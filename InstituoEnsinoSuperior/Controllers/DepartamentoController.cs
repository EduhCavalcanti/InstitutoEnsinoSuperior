using InstituoEnsinoSuperior.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using InstituoEnsinoSuperior.Models;
using System.Collections.Generic;

namespace InstituoEnsinoSuperior.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;

        //Contrutor para injeção de dependência
        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        //Método para listar os departamentos 
        public IActionResult Index()
        {
            List<Departamento> departamentos = _context.Departamentos.ToList();
            return View(departamentos);
        }
    }
}