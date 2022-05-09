using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    public partial class Ustensile
    {
        public Ustensile()
        {
            RecetteUstenciles = new HashSet<RecetteUstencile>();
        }

        [Key]
        [Column("Id_Ustensiles")]
        public int IdUstensiles { get; set; }
        [Column("nom_ustensile")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomUstensile { get; set; }

        [InverseProperty("IdUstensilesNavigation")]
        public virtual ICollection<RecetteUstencile> RecetteUstenciles { get; set; }
    }
}
