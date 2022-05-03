using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExamenAWSAlvaroMoyaHerraiz.Models
{
    [Table("APUESTAS")]
    public class Apuesta
    {
        [Key]
        [Column("IDAPUESTA")]
        public int IdApuesta { get; set; }

        [Column("USUARIO")]
        public string Usuario { get; set; }

        [Column("IDEQUIPOLOCAL")]
        public int IdLocal { get; set; }

        [Column("IDEQUIPOVISITANTE")]
        public int IdVisitante { get; set; }

        [Column("GOLESEQUIPOLOCAL")]
        public int GolesLocal { get; set; }

        [Column("GOLESEQUIPOVISITANTE")]
        public int GolesVisitante { get; set; }
    }
}
