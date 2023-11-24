using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    public class RegionsLogic : IRegionsLogic
    {
        public IRepository<Regions> repo;
        public RegionsLogic(IRepository<Regions> repo)
        {
            this.repo = repo;
        }
        public void Create(Regions region)
        {
            if (region.Name.Length <= 3)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.repo.Create(region);
        }
        public void Delete(int id)
        {
            try
            {
                var item = repo.Read(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("ID does not exist!");
            }
            this.repo.Delete(id);
        }
        public Regions Read(int id)
        {
            Regions item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("ID does not exist!");
            }
            return item;
        }
        public IQueryable<Regions> ReadAll()
        {
            return this.repo.ReadAll();
        }
        public void Update(Regions region)
        {
            this.repo.Update(region);
        }
    }
}
