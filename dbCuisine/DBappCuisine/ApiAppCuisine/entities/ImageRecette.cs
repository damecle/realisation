using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("imageRecette")]
    public partial class ImageRecette
    {
        [Key]
        [Column("Id_Photo")]
        public int IdPhoto { get; set; }
        [Column("nom_photo")]
        [Unicode(false)]
        public string? NomPhoto { get; set; }
        [Column("Id_Recette")]
        public int IdRecette { get; set; }

        [ForeignKey("IdRecette")]
        [InverseProperty("ImageRecettes")]
        public virtual Recette IdRecetteNavigation { get; set; } = null!;
    }
}
