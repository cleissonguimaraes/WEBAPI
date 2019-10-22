using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace apimycell.Models
{
    public class MeuContext : DbContext {

        public MeuContext() : base("name=MeuContext")
        {
        }

        public virtual DbSet<Pessoa> Pessoas{ get; set; }
    }

}