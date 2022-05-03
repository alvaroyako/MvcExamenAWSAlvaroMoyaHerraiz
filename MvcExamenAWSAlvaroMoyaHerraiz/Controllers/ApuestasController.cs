using Microsoft.AspNetCore.Mvc;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using MvcExamenAWSAlvaroMoyaHerraiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Controllers
{
    public class ApuestasController : Controller
    {

        private RepositoryChampions repo;

        public ApuestasController(RepositoryChampions repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            ViewData["EQUIPOS"] = equipos;
            return View(this.repo.GetApuestas());
        }

        [HttpPost]
        public IActionResult Index(string usuario,int idlocal,int idvisitante,int gollocal,int golvisitante)
        {
            Apuesta apuesta = new Apuesta();
            apuesta.IdApuesta = this.repo.GetMaxIdApuesta();
            apuesta.Usuario = usuario;
            apuesta.IdLocal = idlocal;
            apuesta.IdVisitante = idvisitante;
            apuesta.GolesLocal = gollocal;
            apuesta.GolesVisitante = golvisitante;
            this.repo.CrearApuesta(apuesta);
            return RedirectToAction("Index");
        }
    }
}
