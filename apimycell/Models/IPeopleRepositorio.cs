using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apimycell.Models
{
    public interface IPeopleRepositorio
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa Get(int id);
        Pessoa Add(Pessoa pessoa);
        void Remove(int id);
        bool Update(Pessoa pessoa);
    }
}
