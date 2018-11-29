namespace Data
{
    using System;
    
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;
    using System.Data.Entity;

    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<rendezvou> rendezvous { get; set; }
        public virtual DbSet<user> users { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<rendezvou>()
                .Property(e => e.desciption)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.sujet)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.id_adherent)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.id_employe)
                .IsUnicode(false);

            modelBuilder.Entity<rendezvou>()
                .Property(e => e.reponse)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.mdp)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nationalite)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nom_utilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.situation)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.registre_commerce)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.rendezvous)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.id_adherent);

            modelBuilder.Entity<user>()
                .HasMany(e => e.rendezvous1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.id_employe);
        }
    }
}
