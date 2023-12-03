using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SWZZPI_HFT_2023241.Models
{
    public class Champions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string Species { get; set; }        
        [StringLength(100)]
        public string Lane { get; set; }
        [Required]
        public int ReleaseYear { get; set; }       
        public int RegionsId { get; set; } 
        [ForeignKey(nameof(RegionsId))]
        public virtual Regions Region { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Abilities> Abilities { get; set; }
        public Champions()
        {
            Abilities = new HashSet<Abilities>();
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
