using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace apimycell.Models
{
    public class Celula
    {
        [Key]
        public int CelulaId { get; set; }
        public string Name { get; set; }
        public DayOfWeek Dia { get; set; }
        public string Horario { get; set; }
        public int? EnderecoId { get; set; }
    }
}