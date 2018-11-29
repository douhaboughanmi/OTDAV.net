namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetpi.rendezvous")] 
    public partial class rendezvou
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string desciption { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        public TimeSpan? heure { get; set; }

        public TimeSpan? heure_fin { get; set; }

        [StringLength(255)]
        public string sujet { get; set; }

        [StringLength(255)]
        public string id_adherent { get; set; }

        [StringLength(255)]
        public string id_employe { get; set; }

        [StringLength(255)]
        public string reponse { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
