using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("recette_ustencile")]
    public partial class RecetteUstencile
    {
        [Key]
        [Column("Id_Recette")]
        public int IdRecette { get; set; }
        [Key]
        [Column("Id_Ustensiles")]
        public int IdUstensiles { get; set; }
        [Column("quantite_ustencile")]
        public int? QuantiteUstencile { get; set; }

        [ForeignKey("IdRecette")]
        [InverseProperty("RecetteUstenciles")]
        public virtual Recette IdRecetteNavigation { get; set; } = null!;
        [ForeignKey("IdUstensiles")]
        [InverseProperty("RecetteUstenciles")]
        public virtual Ustensile IdUstensilesNavigation { get; set; } = null!;
    }
}
