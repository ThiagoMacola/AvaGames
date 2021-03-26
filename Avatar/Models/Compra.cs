using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Avatar.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [DisplayName("Codigo Premium")]
        public long CodigoJogo { get; set; }
        [DisplayName("Forma Pagamento")]
        public string FormaPagamento { get; set; }
		public virtual Comprador Comprador { get; set; }
        [DisplayName("Data Compra")]
        public DateTime DataCompra { get; set; }



    }
}