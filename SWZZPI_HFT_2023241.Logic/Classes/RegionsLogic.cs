using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    public class RegionsLogic : IRegionsLogic
    {
        public IRepository<Regions> RegionsRepo;
        public RegionsLogic(IRepository<Regions> repo)
        {
            this.RegionsRepo = repo;
        }
        public void Create(Regions region)
        {
            if (region.Name.Length < 3)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.RegionsRepo.Create(region);
        }
        public void Delete(int id)
        {
            try
            {
                var item = RegionsRepo.Read(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("ID does not exist!");
            }
            this.RegionsRepo.Delete(id);
        }
        public Regions Read(int id)
        {
            Regions item = RegionsRepo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("ID does not exist!");
            }
            return item;
        }
        public IQueryable<Regions> ReadAll()
        {
            return this.RegionsRepo.ReadAll();
        }
        public void Update(Regions region)
        {
            this.RegionsRepo.Update(region);
        }
    }
}
