using Microsoft.AspNetCore.Mvc;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using MvcExamenAWSAlvaroMoyaHerraiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Controllers
{
    public class EquiposController : Controller
    {
        private RepositoryChampions repo;

        public EquiposController(RepositoryChampions repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
    }
}
