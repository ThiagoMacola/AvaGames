using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Avatar.Models
{
    public class ContaUsuario
    {

        public  int Id { get; set; }
       
        [DisplayName("Nome")]
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [DisplayName("Status da Conta")]
        public bool StatusConta { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }
        public virtual Personagem Personagem { get; set; }
       

     

    }
}