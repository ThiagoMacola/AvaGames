using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Avatar.Models
{
    public class Classe
    {      


        [DisplayName("Tipo")]
        public string NomeClasse { get; set; }


        [DisplayName("Raça")]
        public string RacaClasse { get; set; }
      

    }
}