using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("Recette")]
    public partial class Recette
    {
        public Recette()
        {
            EtapeRecettes = new HashSet<EtapeRecette>();
            ImageRecettes = new HashSet<ImageRecette>();
            RecetteIngrdients = new HashSet<RecetteIngrdient>();
            RecetteUstenciles = new HashSet<RecetteUstencile>();
        }

        [Key]
        [Column("Id_Recette")]
        public int IdRecette { get; set; }
        [Column("nom_recette")]
        [Unicode(false)]
        public string? NomRecette { get; set; }
        [Column("nbr_personne")]
        public int? NbrPersonne { get; set; }
        [Column("description_recette")]
        [Unicode(false)]
        public string? DescriptionRecette { get; set; }
        [Column("temps")]
        public int? Temps { get; set; }
        [Column("favoris")]
        public bool? Favoris { get; set; }
        [Column("note")]
        public int? Note { get; set; }
        [Column("is_public")]
        public bool? IsPublic { get; set; }
        [Column("Id_User")]
        public int IdUser { get; set; }
        [Column("Id_Type_recette")]
        public int IdTypeRecette { get; set; }

        [ForeignKey("IdTypeRecette")]
        [InverseProperty("Recettes")]
        public virtual TypeRecette IdTypeRecetteNavigation { get; set; } = null!;
        [ForeignKey("IdUser")]
        [InverseProperty("Recettes")]
        public virtual User IdUserNavigation { get; set; } = null!;
        [InverseProperty("IdRecetteNavigation")]
        public virtual ICollection<EtapeRecette> EtapeRecettes { get; set; }
        [InverseProperty("IdRecetteNavigation")]
        public virtual ICollection<ImageRecette> ImageRecettes { get; set; }
        [InverseProperty("IdRecetteNavigation")]
        public virtual ICollection<RecetteIngrdient> RecetteIngrdients { get; set; }
        [InverseProperty("IdRecetteNavigation")]
        public virtual ICollection<RecetteUstencile> RecetteUstenciles { get; set; }
    }
}
