using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apimycell.Models
{
    public class PeopleRepositorio : IPeopleRepositorio
    {
        private List<Pessoa> pessoas = new List<Pessoa>();
        private int _nextId = 1;

        public PeopleRepositorio()
        {
           /* Add(new Pessoa { Nome = "Cleisson", endereco = "Rua Pedro II, 672", bairro = "Filadelfia", telefone = "993225889", funcao = "lider" });
            Add(new Pessoa { Nome = "Thalita", endereco = "Rua Maximiliana dos Anjos, 182", bairro = "Filadelfia", telefone = "993431132", funcao = "secretaria" });
            Add(new Pessoa { Nome = "Talisson", endereco = "Rua Leozino de Oliveira, 417", bairro = "Filadelfia", telefone = "991328473", funcao = "anfitriao" });
            Add(new Pessoa { Nome = "Leandro", endereco = "Rua Salmonela, 45", bairro = "Sao Joao", telefone = "987321145", funcao = "membro" });
            Add(new Pessoa { Nome = "Vinicius", endereco = "Rua Alexandre Bernardino Costa, 250", bairro = "Petropolis", telefone = "993567686", funcao = "membro" });
            */

        }

        public Pessoa Add(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                throw new ArgumentNullException("pessoa");
            }
            pessoa.PessoaId = _nextId++;
            pessoas.Add(pessoa);
            return pessoa;
        }

        public Pessoa Get(int id)
        {
            return pessoas.Find(p => p.PessoaId == id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return pessoas;
        }

        public void Remove(int id)
        {
            pessoas.RemoveAll(p => p.PessoaId == id);
        }

        public bool Update(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                throw new ArgumentNullException("pessoa");
            }

            int index = pessoas.FindIndex(p => p.PessoaId == pessoa.PessoaId);

            if (index == -1)
            {
                return false;
            }

            pessoas.RemoveAt(index);
            pessoas.Add(pessoa);
            return true;
        }

    }
}