using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoprofsXyn.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Naam")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Wachtwoord")]
        [Display(Name = "Wachtwoord")]
        public string Wachtwoord { get; set; }

        [Required]
        [Column("VerlofUren")]
        [Display(Name = "Verlof Uren")]
        public int VerlofUren { get; set; }

        [DisplayFormat(NullDisplayText = "Geen Verlof Aanvraag")]
        public ICollection<Verlof>? Verlof { get; set; }
        public ICollection<Team> Team { get; set; }
        public ICollection<Rol> Rol { get; set; }
    }
}
