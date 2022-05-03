using Microsoft.Extensions.Configuration;
using MvcExamenAWSAlvaroMoyaHerraiz.Data;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Repositories
{
    public class RepositoryChampions
    {
        private ChampionContext context;
        public RepositoryChampions(IConfiguration configuration,ChampionContext context)
        {
            this.context = context;
        }

        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public List<Jugador> GetJugadores(int idequipo)
        {
            var consulta = from datos in this.context.Jugadores
                           where datos.IdEquipo == idequipo
                           select datos;
            return consulta.ToList();
        }

        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }

        public Equipo FindEquipo(int idequipo)
        {
            return this.context.Equipos.SingleOrDefault(x => x.IdEquipo == idequipo);
        }

        public Jugador FindJugador(int idjugador)
        {
            return this.context.Jugadores.SingleOrDefault(x => x.IdJugador == idjugador);
        }

        public Apuesta FindApuesta(int idapuesta)
        {
            return this.context.Apuestas.SingleOrDefault(x => x.IdApuesta == idapuesta);
        }

        public void CrearJugador(Jugador jugador)
        {
            this.context.Jugadores.Add(jugador);
            this.context.SaveChanges();
        }

        public void CrearApuesta(Apuesta apuesta)
        {
            this.context.Apuestas.Add(apuesta);
            this.context.SaveChanges();
        }

        public int GetMaxIdApuesta()
        {
            if (this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            }
        }

    }
}
