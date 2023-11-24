using SWZZPI_HFT_2023241.Models;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
    interface IAbilitiesLogic
    {
        void Create(Abilities ability);
        Abilities Read(int id);
        IQueryable<Abilities> ReadAll();
        void Update(Abilities ability);
        void Delete(int id);
    }
}
