using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("imageIngredient")]
    public partial class ImageIngredient
    {
        [Key]
        [Column("Id_Photo")]
        public int IdPhoto { get; set; }
        [Column("nom_photo")]
        [Unicode(false)]
        public string? NomPhoto { get; set; }
        [Column("Id_Ingredient")]
        public int IdIngredient { get; set; }

        [ForeignKey("IdIngredient")]
        [InverseProperty("ImageIngredients")]
        public virtual Ingredient IdIngredientNavigation { get; set; } = null!;
    }
}
