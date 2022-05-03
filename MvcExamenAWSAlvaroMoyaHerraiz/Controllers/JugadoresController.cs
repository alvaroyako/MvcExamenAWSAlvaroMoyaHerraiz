using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using MvcExamenAWSAlvaroMoyaHerraiz.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoryChampions repo;

        public JugadoresController(RepositoryChampions repo)
        {
            this.repo = repo;
        }

        public IActionResult Index(int idequipo)
        {
            List<Jugador> jugadores = this.repo.GetJugadores(idequipo) ;
            ViewData["ID"] = idequipo;
            return View(jugadores);
        }

        public IActionResult Create(int idequipo)
        {
            Equipo equipo = this.repo.FindEquipo(idequipo);
            ViewData["IDEQUIPO"] = equipo.IdEquipo;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int idjugador,string nombre,string posicion,IFormFile imagen,int idequipo)
        {
            Jugador jugador = new Jugador();
            jugador.IdJugador = idjugador;
            jugador.Nombre = nombre;
            jugador.Posicion = posicion;
            jugador.Imagen = imagen.FileName;
            jugador.IdEquipo = idequipo;
            this.repo.CrearJugador(jugador);
            using (Stream stream = imagen.OpenReadStream())
            {
                await this.repo.UploadFile(stream, imagen.FileName);
            }
                
            return RedirectToAction("Index",new { idequipo=idequipo});
        }
    }
}
