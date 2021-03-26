using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Avatar.Models;

namespace Avatar.Dao
{
    public class AvatarInitializer : DropCreateDatabaseIfModelChanges<AvatarContext>
    {

        protected override void Seed(AvatarContext context)
        {
            var contaUsuarios = new List<ContaUsuario>
            {

               //new ContaUsuario{ Id = 1, Email = "fernando@gmail.com",
               //    StatusConta = false, Senha = "1234", NomeUsuario = "Fernando", DataCriacao = DateTime.Now,
               //    Personagem = new Personagem { Id = 1, Nome = "",Sexo = "M", Url = "https://image.shutterstock.com/image-vector/pixel-art-red-haired-warrior-600w-661627120.jpg",
               //    Classe = new Classe {  NomeClasse = "Guerreiro", RacaClasse = "Humano" }
               //    }
               // }
            };
            var compras = new List<Compra>
            {
                //new Compra{ Id = 1, Cpf = "44216208827", NomeComprador = "Thiago", FormaPagamento = "Boleto", DataCompra = DateTime.Now},
                //new Compra{ Id = 2, Cpf = "11111111111", NomeComprador = "Fernando", FormaPagamento = "Cartão de Credito", DataCompra = DateTime.Now}

            };

            
            compras.ForEach(d => context.Compras.Add(d));
            contaUsuarios.ForEach(x => context.ContasUsuarios.Add(x));
            context.SaveChanges();


        }

    }
}