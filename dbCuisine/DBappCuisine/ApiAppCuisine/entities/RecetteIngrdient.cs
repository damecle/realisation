using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("recette_ingrdients")]
    public partial class RecetteIngrdient
    {
        [Key]
        [Column("Id_Recette")]
        public int IdRecette { get; set; }
        [Key]
        [Column("Id_Ingredient")]
        public int IdIngredient { get; set; }
        [Column("quantite_ingredient", TypeName = "decimal(15, 2)")]
        public decimal? QuantiteIngredient { get; set; }
        [Column("untite")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Untite { get; set; }

        [ForeignKey("IdIngredient")]
        [InverseProperty("RecetteIngrdients")]
        public virtual Ingredient IdIngredientNavigation { get; set; } = null!;
        [ForeignKey("IdRecette")]
        [InverseProperty("RecetteIngrdients")]
        public virtual Recette IdRecetteNavigation { get; set; } = null!;
    }
}
