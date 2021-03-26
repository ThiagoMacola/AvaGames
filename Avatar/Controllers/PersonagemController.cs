using Avatar.Dao;
using Avatar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avatar.Controllers
{
    public class PersonagemController : Controller
    {
        private AvatarContext db = new AvatarContext();
        //GET: Personagem
       
        public ActionResult Create()
        {

            return View();
        }

    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personagem personagem)
        {
            Classe tipo = new Classe();
            int escolha;
            escolha = int.Parse(personagem.Url);
            //new Personagem {Classe = new Classe { } };
          
            if (ModelState.IsValid)
            {
				switch (escolha)
				{
                    case 1 :
                      
                        tipo.NomeClasse = "Mago";
                        tipo.RacaClasse = "Humano";
                        personagem.Classe = tipo;
                        personagem.Sexo = "Homem";
                        personagem.Url = "~/Fotos/arte1.jpg";
                    break;

                    case 2 :
                        tipo.NomeClasse = "Curandeira";
                        tipo.RacaClasse = "Humano";
                        personagem.Classe = tipo;
                        personagem.Sexo = "Mulher";
                        personagem.Url = "~/Fotos/arte2.jpg";
                        break;
                    
                    case 3 :
                        tipo.NomeClasse = "Guerreiro";
                        tipo.RacaClasse = "Humano";
                        personagem.Classe = tipo;
                        personagem.Sexo = "Homem";
                        personagem.Url = "~/Fotos/arte3.jpg";
                        break;
                    case 4 :
                        tipo.NomeClasse = "Arqueiro";
                        tipo.RacaClasse = "Humano";
                        personagem.Classe = tipo;
                        personagem.Sexo = "Mulher";
                        personagem.Url = "~/Fotos/arte4.jpg";

                        break;
                }
				db.Personagens.Add(personagem);

                db.SaveChanges();
                return RedirectToAction("Details", new { id = personagem.Id });
            }

            return View(personagem);
        }
   

        public ActionResult Details(int id)
        {
            return View(db.Personagens.First(p => p.Id == id));
        }

    }
}