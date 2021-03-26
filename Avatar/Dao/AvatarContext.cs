using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Avatar.Models;

namespace Avatar.Dao
{
    public class AvatarContext : DbContext
    {

        public AvatarContext() : base("AvatarContext")
        {

        }

        public DbSet<ContaUsuario> ContasUsuarios { set; get; }
        public DbSet<Personagem> Personagens { set; get; }
        public DbSet<Compra> Compras { set; get; }
      


    }
}