using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Avatar.Models
{
    public class Personagem
    {
      
       public int Id { get; set; }
       public string Nome { get; set; }
       public string Sexo { get; set; }
       public string Url { get; set; }
       public virtual Classe Classe { get; set; }


        
    
    }
}