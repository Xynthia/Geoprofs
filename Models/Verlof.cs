using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoprofsXyn.Models
{
    public class Verlof
    {
        [Key]
        public int Id { get; set; }

        public ICollection<VerlofSoort> VerlofSoort { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z]*$")]
        [Column("Naam")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required]
        [StringLength(150)]
        [Column("Omschrijving")]
        [Display(Name = "Omschrijving")]
        public string Omschrijving { get; set; }

        [Required]
        [Column("BeginDatum")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Begin Datum")]
        public DateTime BeginDatum { get; set; }

        [Required]
        [Column("EindDatum")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Eind Datum")]
        public DateTime EindDatum { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
