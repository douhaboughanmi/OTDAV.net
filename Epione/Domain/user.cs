namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetpi.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            rendezvous = new HashSet<rendezvou>();
            rendezvous1 = new HashSet<rendezvou>();
        }

        [Required]
        [StringLength(31)]
        public string DTYPE { get; set; }

        [Key]
        [StringLength(255)]
        public string cin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_de_naissance { get; set; }

        public int fax { get; set; }

        [StringLength(255)]
        public string mdp { get; set; }

        [StringLength(255)]
        public string nationalite { get; set; }

        public int nbr_points { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string nom_utilisateur { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(255)]
        public string situation { get; set; }

        public int telephone { get; set; }

        [StringLength(255)]
        public string registre_commerce { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvou> rendezvous { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvou> rendezvous1 { get; set; }
    }
}
