using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class ExamenContext:DbContext
    {

        //public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Class2> Class2 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Changer le nom de la base
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=true;MultipleActiveResultSets=True");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///Personnalisation des tables : Cle primaire, discriminator..
            //modelBuilder.Entity<Contrat>().HasKey(c => new { c.DateContrat, c.EquipeFK, c.MembreFK });
            //modelBuilder.Entity<Membre>().HasDiscriminator<string>("Type").HasValue<Entraineur>("E").HasValue<Joueur>("J");
            
            // Changer le nom d une table en mappant
            modelBuilder.Entity<Class2>().ToTable("Test");
            //modelBuilder.Entity<Joueur>().ToTable("Joueurs");

            //Appliquer une config externe
            //new TropheeConfiguration().Configure(modelBuilder.Entity<Trophee>());
            

            base.OnModelCreating(modelBuilder);
        }


    }
}
