using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
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
    }
}
