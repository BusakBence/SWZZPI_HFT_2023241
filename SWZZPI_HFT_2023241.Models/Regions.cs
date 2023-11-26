using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SWZZPI_HFT_2023241.Models
{
    public class Regions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(100)]
        public string TechnologyLevel { get; set; }
        [StringLength(100)]
        public string FormOfGovernment { get; set; }
        [StringLength(100)]
        public string Environment { get; set; }
        [JsonIgnore]
        public virtual ICollection<Champions> Champions { get; set; }
        public Regions()
        {
            Champions = new HashSet<Champions>();
        }
        public Regions(string line)
        {           
            string[] split = line.Split('*');
            Id = int.Parse(split[0]);
            Name = split[1];
            Location = split[2];
            TechnologyLevel = split[3];
            FormOfGovernment = split[4];
            Environment = split[5];
        }
    }
}
