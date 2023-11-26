using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    public class ChampionsLogic : IChampionsLogic
    {
        public IRepository<Champions> ChampionsRepo;
        public IRepository<Regions> RegionsRepo;
        public IRepository<Abilities> AbilitiesRepo;
        public ChampionsLogic(IRepository<Champions> championsrepo, IRepository<Regions> regionsrepo, IRepository<Abilities> abilitiesrepo)
        {
            this.ChampionsRepo = championsrepo;
            this.RegionsRepo = regionsrepo;
            this.AbilitiesRepo = abilitiesrepo;
        }
        public void Create(Champions champion)
        {
            if (champion.Name.Length <= 1)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.ChampionsRepo.Create(champion);
        }
        public void Delete(int id)
        {
            try
            {
                var champion = ChampionsRepo.Read(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("ID does not exist!");
            }
            this.ChampionsRepo.Delete(id);
        }
        public Champions Read(int id)
        {
            Champions champion = ChampionsRepo.Read(id);
            if (champion == null)
            {
                throw new ArgumentException("ID does not exist!");
            }
            return champion;
        }
        public IQueryable<Champions> ReadAll()
        {
            return this.ChampionsRepo.ReadAll();
        }
        public void Update(Champions champion)
        {
            this.ChampionsRepo.Update(champion);
        }
        public List<ShurimaHeros> GetShurimaChampionsBetween2012And2016()
        {
            var champions = ChampionsRepo.ReadAll();
            var regions = RegionsRepo.ReadAll();  

            var result = from champion in champions
                         join region in regions on champion.RegionsId equals region.Id
                         where region.Name == "Shurima" && champion.ReleaseYear >= 2012 && champion.ReleaseYear <= 2016
                         select new ShurimaHeros()
                         {
                             Name = champion.Name,
                             Region = region.Name,
                             Year = champion.ReleaseYear
                         };

            return result.ToList();
        }
        public List<FemalesUltimates> GetFemalesUltimates()
        {
            var champions = ChampionsRepo.ReadAll();
            var abilities = AbilitiesRepo.ReadAll();
            var result = from ability in abilities
                        join champion in champions on ability.ChampionId equals champion.Id
                        where champion.Gender == "Female" && ability.AbilityKey == 'R'
                        select new FemalesUltimates
                        {
                            Name = champion.Name,
                            AbilityName = ability.Name
                        };
            return result.ToList();
        }
    }
    public class ShurimaHeros
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }
        public override bool Equals(object obj)
        {
            ShurimaHeros b = obj as ShurimaHeros;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.Region == b.Region && this.Year == b.Year; 
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Region, this.Year);
        }
    }
    public class FemalesUltimates
    {
        public string Name { get; set; }
        public string AbilityName { get; set; }
        public override bool Equals(object obj)
        {
            FemalesUltimates b = obj as FemalesUltimates;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.AbilityName == b.AbilityName;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.AbilityName);
        }
    }
}
