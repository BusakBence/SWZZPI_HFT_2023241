using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    public class AbilitiesLogic : IAbilitiesLogic
    {
        public IRepository<Abilities> repo;
        public AbilitiesLogic(IRepository<Abilities> repo)
        {
            this.repo = repo;
        }
        public void Create(Abilities ability)
        {
            if (ability.Name.Length <= 3)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.repo.Create(ability);
        }

        public void Delete(int id)
        {
            try
            {
                var ability = repo.Read(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("ID does not exist!");
            }
            this.repo.Delete(id);
        }

        public Abilities Read(int id)
        {
            Abilities ability = repo.Read(id);
            if (ability == null)
            {
                throw new ArgumentException("ID does not exist!");
            }
            return ability;
        }

        public IQueryable<Abilities> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Abilities ability)
        {
            this.repo.Update(ability);
        }
    }
}
