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
            if (champion.Name.Length < 3)
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
        public List<ShurimaChampions> GetShurimaChampionsBetween2012And2016()
        {           
            var regions = RegionsRepo.ReadAll();
            var result = from region in regions
                         from champion in region.Champions                         
                         where region.Name == "Shurima" && champion.ReleaseYear >= 2012 && champion.ReleaseYear <= 2016
                         select new ShurimaChampions()
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
            var result = from champion in champions
                        from ability in champion.Abilities
                        where champion.Gender == "Female" && ability.AbilityKey == 'R'
                        select new FemalesUltimates
                        {
                            Name = champion.Name,
                            AbilityName = ability.Name
                        };
            return result.ToList();
        }
        public List<IonianChampions> GetAllIonianChampions()
        {
            var regions = RegionsRepo.ReadAll();
            var result = from region in regions
                         from champion in region.Champions
                         where region.Name == "Ionia"
                         select new IonianChampions
                         {
                             Name = champion.Name,
                             Region = region.Name
                         };
                         
            return result.ToList();  
        }
        public List<DemacianAbilities> GetDemacianAbilities()
        {
            var regions = RegionsRepo.ReadAll();
            var result = from region in regions
                         from champion in region.Champions
                         from ability in champion.Abilities
                         where region.Name == "Demacia"
                         select new DemacianAbilities
                         {
                             ChampionName = champion.Name,
                             Name = ability.Name,
                             Key = ability.AbilityKey,
                             Region = region.Name
                             
                         };
            return result.ToList();
        }
        public List<DChampionsPAbilities> GetDChampionsPAbilities()
        {
            var champions = ChampionsRepo.ReadAll();           
            var result = from champion in champions
                         from ability in champion.Abilities
                         where champion.Name.StartsWith("D") && ability.AbilityKey == 'P'
                         select new DChampionsPAbilities()
                         {
                             Name = champion.Name,
                             Key = ability.AbilityKey,
                             KeyName = ability.Name
                         };           
            return result.ToList();
        }          
    }   
}
