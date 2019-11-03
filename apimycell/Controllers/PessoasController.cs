using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apimycell.Models;

namespace apimycell.Controllers
{
    public class PessoasController : ApiController
    {
        /*static readonly IPeopleRepositorio repositorio = new PeopleRepositorio();
        public IEnumerable<People> GetAllProdutos()
        {
            return repositorio.GetAll();
        }
        public People GetPessoa(int id)
        {
            People item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<People> GetPessoasPorNome(string nome)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Nome, nome, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostPessoa(People pessoa)
        {
            pessoa = repositorio.Add(pessoa);
            var response = Request.CreateResponse<People>(HttpStatusCode.Created, pessoa);
            string uri = Url.Link("DefaultApi", new { id = pessoa.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutPessoa(int id, People pessoa)
        {
            pessoa.Id = id;
            if (!repositorio.Update(pessoa))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeletePessoa(int id)
        {
            People pessoa = repositorio.Get(id);
            if (pessoa == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }*/
        private DatabaseContext db = new DatabaseContext();

        // GET api/Usuario
        public IEnumerable<Pessoa> GetAllProdutos()
        {
            IEnumerable<Pessoa> pessoas = db.Pessoas.ToList();
            if (pessoas == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pessoas;
        }

        // GET api/Usuario/5
        public Pessoa GetPessoa(int id)
        {
            Pessoa pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return pessoas;
        }

        // PUT api/Usuario/5
        public HttpResponseMessage PutPessoa(int id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != pessoa.PessoaId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(pessoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public Pessoa GetPessoasPorNome(string nome)
        {
            Pessoa pessoas = db.Pessoas.Find(nome);
            if (pessoas == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pessoas;
        }

        // POST api/Usuario
        public HttpResponseMessage PostPessoa(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Pessoas.Add(pessoa);
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, pessoa);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = pessoa.PessoaId }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/Usuario/5
        public HttpResponseMessage DeletePessoa(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Pessoas.Remove(pessoa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
