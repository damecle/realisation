using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("Etape_recette")]
    public partial class EtapeRecette
    {
        [Key]
        [Column("Id_Etape_recette")]
        public int IdEtapeRecette { get; set; }
        [Column("nom_etape")]
        [StringLength(255)]
        [Unicode(false)]
        public string? NomEtape { get; set; }
        [Column("description_etape")]
        [Unicode(false)]
        public string? DescriptionEtape { get; set; }
        [Column("Id_Recette")]
        public int IdRecette { get; set; }

        [ForeignKey("IdRecette")]
        [InverseProperty("EtapeRecettes")]
        public virtual Recette IdRecetteNavigation { get; set; } = null!;
    }
}
