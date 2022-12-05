using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoprofsXyn.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z]*$")]
        [Column("Naam")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }


        public int userId { get; set; }

        public User User { get; set; }
    }
}
