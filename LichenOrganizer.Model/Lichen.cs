using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LichenOrganizer.Model
{
    public class Lichen
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Genus { get; set; }
        [Required]
        public string Species { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int? Elevation { get; set; }
        public DateTime AccessionNumber { get; set; }
        
        public string? ImagePath { get; set; }

        //Navigation Properties
        //[Foreign Key]
        //public List<Tree> Trees { get; set; }


    }
}
