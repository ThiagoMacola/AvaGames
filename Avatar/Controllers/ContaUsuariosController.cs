using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avatar.Dao;
using Avatar.Models;

namespace Avatar.Controllers
{
    public class ContaUsuariosController : Controller
    {
        public AvatarContext db = new AvatarContext();

        public ActionResult DetalhesContaUsuario(int id)
        {
            return View(db.ContasUsuarios.First(p => p.Id == id));
        }
        public ActionResult PaginaCriarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaginaCriarUsuario(ContaUsuario contaUsuario)
        {
            if (ModelState.IsValid)
            {

                contaUsuario.DataCriacao = DateTime.Now;
                db.ContasUsuarios.Add(contaUsuario);

                db.SaveChanges();
                return RedirectToAction("DetalhesContaUsuario", new { id = contaUsuario.Id });
            }

            return View(contaUsuario);
        }
        public ActionResult EdicaoContaUsuario(int id)
        {
            return View(db.ContasUsuarios.First(p => p.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdicaoContaUsuario(ContaUsuario conta)
        {
            if (ModelState.IsValid)
            {
                ContaUsuario contaUpdate = db.ContasUsuarios.First(p => p.Id == conta.Id);

                contaUpdate.NomeUsuario = conta.NomeUsuario;
                contaUpdate.Email = conta.Email;
                contaUpdate.Senha = conta.Senha;

                db.SaveChanges();
                return RedirectToAction("DetalhesContaUsuario", new { id = conta.Id });

            }
            return View(conta);
        }
        public ActionResult ValidarLogin(ContaUsuario conta)
        {

            foreach (var i in db.ContasUsuarios)
            {
                if (i.Email == conta.Email && i.Senha == conta.Senha)
                {
                   
                    return RedirectToAction("DetalhesContaUsuario", new {id = i.Id }); // como retornar um ID DAQUI <-
                }

            };
            if(conta.Email != null && conta.Senha != null)
            {
                return View("AlertLogin");
            }

            return View("ValidarLogin");

        }
        public ActionResult Edit2(int id)
        {
            ContaUsuario c2 = db.ContasUsuarios.First(c => c.Id == id);
            c2.StatusConta = true;
            db.SaveChanges();
            return View(db.ContasUsuarios.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(ContaUsuario conta)
        {
            if (ModelState.IsValid)
            {
                   ContaUsuario c2 = db.ContasUsuarios.First(c => c.Id == conta.Id);
                   c2.StatusConta = true;
                   db.SaveChanges();
                   return RedirectToAction("Index", "Home");
            }
            return View("Edit2");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
