using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    [Table("bj.HORARIO_GIMNASIO")]
    public class Horario
    {
        [Key]
        public int ID_HORARIO { get; set; }
        public string HORA { get; set; }
        public string ACTIVIDAD { get; set; }
        public string DIA { get; set; }
        public int INTIDADMINISTRADOR { get; set; }
        public double INTHORA { get; set; }

    }

    public class HorarioDBContext : DbContext
    {
        public DbSet<Horario> Horario { get; set; }
    }
}