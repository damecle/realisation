using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("Ingredient")]
    public partial class Ingredient
    {
        public Ingredient()
        {
            ImageIngredients = new HashSet<ImageIngredient>();
            RecetteIngrdients = new HashSet<RecetteIngrdient>();
        }

        [Key]
        [Column("Id_Ingredient")]
        public int IdIngredient { get; set; }
        [Column("nom_ingredient")]
        [Unicode(false)]
        public string? NomIngredient { get; set; }

        [InverseProperty("IdIngredientNavigation")]
        public virtual ICollection<ImageIngredient> ImageIngredients { get; set; }
        [InverseProperty("IdIngredientNavigation")]
        public virtual ICollection<RecetteIngrdient> RecetteIngrdients { get; set; }
    }
}
