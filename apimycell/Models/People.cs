using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apimycell.Models
{
    public class People
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string telefone { get; set; }
        public string funcao { get; set; }
    }
}