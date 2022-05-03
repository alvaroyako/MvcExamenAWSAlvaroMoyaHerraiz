using Microsoft.EntityFrameworkCore;
using MvcExamenAWSAlvaroMoyaHerraiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Data
{
    public class ChampionContext: DbContext
    {
        public ChampionContext(DbContextOptions<ChampionContext> options) : base(options) { }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
    }
}
