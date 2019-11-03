using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace apimycell.Models
{
    public class DatabaseContext : DbContext {

        public DatabaseContext() : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Pessoa> Pessoas{ get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }

}