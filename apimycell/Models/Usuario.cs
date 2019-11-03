using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apimycell.Models
{
    public enum UserStatus
    {
        PrimeiroAcesso = 0,
        Ativo = 1,
        Reset = 2,
        Bloqueado = 3
    }
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        //public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }

        [NotMapped]
        public string MsgErro { get; set; }
        [NotMapped]
        public string Nome { get; set; }


        public virtual Pessoa Pessoa { get; set; }

    }
}