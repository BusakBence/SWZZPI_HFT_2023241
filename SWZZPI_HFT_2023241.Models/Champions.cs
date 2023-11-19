using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWZZPI_HFT_2023241.Models
{
    public class Champions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(240)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        [Required]
        public string Lane { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required, ForeignKey(nameof(Region))]
        public int RegionsId { get; set; }
        public virtual Regions Region { get; set; }
        public virtual ICollection<Abilities> Abilities { get; set; }
        public virtual ICollection<Regions> Regions { get; set; }
        public Champions()
        {
            Abilities = new HashSet<Abilities>();
            Regions = new HashSet<Regions>();
        }
        public Champions(string line)
        {
            string[] split = line.Split('*');
            Id = int.Parse(split[0]);
            Name = split[1];
            Gender = split[2];
            Species = split[3];
            Lane = split[4];
            ReleaseYear = int.Parse(split[5]);
            RegionsId = int.Parse(split[6]);
        }
    }
}
