using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avatar.Dao;
using Avatar.Models;
using CpfLibrary;

namespace Avatar.Controllers
{
	public class CompraController : Controller
	{
	
		private AvatarContext db = new AvatarContext();


		public ActionResult PaginaInserirDadosCompra()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult PaginaInserirDadosCompra(Compra compra)
		{
			if (ModelState.IsValid)
			{

				bool testeCpf = ValidaCpf(compra.Comprador.CPF);
				if (!testeCpf)
				{
					return View("AlertCpf");
				}


				Random random = new Random();
				compra.CodigoJogo = random.Next(500, 150000);
				compra.DataCompra = DateTime.Now;
				db.Compras.Add(compra);
				db.SaveChanges();

				return RedirectToAction("PaginaDetalhesCompra", new { id = compra.Id });
			}
			return View(compra);
		}

		public ActionResult PaginaDetalhesCompra(int id)
		{
			return View(db.Compras.First(d => d.Id == id));
		}

		public bool ValidaCpf(string CPF)
		{
			bool testeCpf = false;
			testeCpf = Cpf.Check(CPF);
			return testeCpf;
		}








	}
}