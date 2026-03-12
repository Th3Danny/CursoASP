using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CursoASPAjax
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paises>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Paises>()
                .HasMany(e => e.Personas)
                .WithOptional(e => e.Paises)
                .HasForeignKey(e => e.idPais);

            modelBuilder.Entity<Personas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }


    }
}
