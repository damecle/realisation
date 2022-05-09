using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCuisine.entities
{
    public partial class User
    {
        public User()
        {
            Recettes = new HashSet<Recette>();
        }

        [Key]
        [Column("Id_User")]
        public int IdUser { get; set; }
        [Column("nom_user")]
        [StringLength(255)]
        [Unicode(false)]
        public string? NomUser { get; set; }
        [Column("email_user")]
        [Unicode(false)]
        public string? EmailUser { get; set; }
        [Column("password")]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("pseudo")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Pseudo { get; set; }
        [Column("admin")]
        public int? Admin { get; set; }

        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Recette> Recettes { get; set; }
    }
}
