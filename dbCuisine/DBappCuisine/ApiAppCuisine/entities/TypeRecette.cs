using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    [Table("Type_recette")]
    public partial class TypeRecette
    {
        public TypeRecette()
        {
            Recettes = new HashSet<Recette>();
        }

        [Key]
        [Column("Id_Type_recette")]
        public int IdTypeRecette { get; set; }
        [Column("nom_type_recette")]
        [StringLength(255)]
        [Unicode(false)]
        public string? NomTypeRecette { get; set; }

        [InverseProperty("IdTypeRecetteNavigation")]
        public virtual ICollection<Recette> Recettes { get; set; }
    }
}
