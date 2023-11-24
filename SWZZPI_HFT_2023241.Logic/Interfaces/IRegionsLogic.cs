using SWZZPI_HFT_2023241.Models;
using System.Linq;


namespace SWZZPI_HFT_2023241.Logic
{
    interface IRegionsLogic
    {
        void Create(Regions region);
        Regions Read(int id);
        IQueryable<Regions> ReadAll();
        void Update(Regions region);
        void Delete(int id);
    }
}
