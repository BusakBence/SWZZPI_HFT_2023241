using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWZZPI_HFT_2023241.Models
{
    public class Abilities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public char AbilityKey { get; set; }   
        [Required]
        public int ChampionId { get; set; }    
        [ForeignKey(nameof(ChampionId))]
        public virtual Champions Champion { get; set; }    
        public Abilities(string line)
        {
            string[] split = line.Split('*');
            Id = int.Parse(split[0]);
            Name = split[1];
            AbilityKey = char.Parse(split[2]);
            ChampionId = int.Parse(split[3]);
        }
    }
}
