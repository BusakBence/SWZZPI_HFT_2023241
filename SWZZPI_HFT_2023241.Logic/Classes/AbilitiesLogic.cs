using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    public class AbilitiesLogic : IAbilitiesLogic
    {
        public IRepository<Abilities> AbilitiesRepo;
        public AbilitiesLogic(IRepository<Abilities> repo)
        {
            this.AbilitiesRepo = repo;
        }
        public void Create(Abilities ability)
        {
            if (ability.Name.Length < 3)
            {
                throw new ArgumentException("Name is too short!");
            }
            this.AbilitiesRepo.Create(ability);
        }
        public void Delete(int id)
        {
            try
            {
                var ability = AbilitiesRepo.Read(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("ID does not exist!");
            }
            this.AbilitiesRepo.Delete(id);
        }
        public Abilities Read(int id)
        {
            Abilities ability = AbilitiesRepo.Read(id);
            if (ability == null)
            {
                throw new ArgumentException("ID does not exist!");
            }
            return ability;
        }
        public IQueryable<Abilities> ReadAll()
        {
            return this.AbilitiesRepo.ReadAll();
        }
        public void Update(Abilities ability)
        {
            this.AbilitiesRepo.Update(ability);
        }
    }
}
