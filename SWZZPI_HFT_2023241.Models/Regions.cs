using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWZZPI_HFT_2023241.Models
{
    public class Regions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public string TechnologyLevel { get; set; }
        public string FormOfGovernment { get; set; }
        public string Environment { get; set; }
        public ICollection<Champions> Champions { get; set; }
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
