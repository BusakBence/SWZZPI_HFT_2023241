using SWZZPI_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWZZPI_HFT_2023241.Logic
{
     public interface IChampionsLogic
    {
        void Create(Champions champion);
        Champions Read(int id);
        IQueryable<Champions> ReadAll();
        void Update(Champions champion);
        void Delete(int id);
        List<ShurimaChampions> GetShurimaChampionsBetween2012And2016();
        List<FemalesUltimates> GetFemalesUltimates();
        List<IonianChampions> GetAllIonianChampions();
        List<DemacianAbilities> GetDemacianAbilities();
        List<DChampionsPAbilities> GetDChampionsPAbilities();
    }
}
