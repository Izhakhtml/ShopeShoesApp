using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopeShoesApp.Models
{
    public partial class OutShoeModel : DbContext
    {
        public OutShoeModel()
            : base("name=OutShoeModel")
        {
        }

        public virtual DbSet<OutShoes> OutShoe { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
