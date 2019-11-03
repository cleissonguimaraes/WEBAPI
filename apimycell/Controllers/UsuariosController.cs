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
    public class UsuariosController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET api/Usuario
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = db.Usuarios.ToList();
            if (usuarios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return usuarios;
        }

        // GET api/Usuario/5
        public Usuario GetUsuario(int id)
        {
            Usuario usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return usuarios;
        }

        // PUT api/Usuario/5
        public HttpResponseMessage PutUsuario(int id, Usuario usuarios)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != usuarios.UsuarioId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(usuarios).State = EntityState.Modified;

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

        public Usuario GetUsuarioPorNome(string nome)
        {
            Usuario usuarios = db.Usuarios.Find(nome);
            if (usuarios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return usuarios;
        }

        // POST api/Usuario
        public HttpResponseMessage PostUsuario(Usuario usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuarios);
                    db.SaveChanges();

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuarios);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuarios.PessoaId }));
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
        public HttpResponseMessage DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Usuarios.Remove(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
