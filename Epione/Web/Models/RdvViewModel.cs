using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Web.Models
{
    public class RdvViewModel
    {
        public int id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-mm-dd}")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "date")]
     
        public DateTime? date { get; set; }
     //   public TimeSpan? heure { get; set; }

        [Required]
        [StringLength(255)]
        public string desciption { get; set; }

      

        [Required]
        [StringLength(255)]
        public string sujet { get; set; }

        [StringLength(255)]
        public string etat { get; set; }


    }
}