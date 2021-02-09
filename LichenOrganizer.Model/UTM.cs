using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LichenOrganizer.Model
{
    public class UTM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Eastings { get; set; }
        [Required]
        public double Northings { get; set; }




        //Navigation objects
        [ForeignKey("LichenId")]
        public int LichenId { get; set; }
        public virtual Lichen Lichen { get; set; }
    }
}
