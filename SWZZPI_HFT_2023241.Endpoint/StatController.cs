using Microsoft.AspNetCore.Mvc;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SWZZPI_HFT_2023241.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IChampionsLogic ChampionsLogic;
        public StatController(IChampionsLogic logic)
        {
            this.ChampionsLogic = logic;
        }
        [HttpGet]
        public List<ShurimaChampions> GetShurimaChampionsBetween2012And2016()
        {
            return this.ChampionsLogic.GetShurimaChampionsBetween2012And2016();
        }
        [HttpGet]
        public List<FemalesUltimates> GetFemalesUltimates()
        {
            return this.ChampionsLogic.GetFemalesUltimates();
        }
        [HttpGet]
        public List<IonianChampions> GetAllIonianChampions()
        {
            return this.ChampionsLogic.GetAllIonianChampions();
        }
        [HttpGet]
        public List<DemacianAbilities> GetDemacianAbilities()
        {
            return this.ChampionsLogic.GetDemacianAbilities();
        }
        [HttpGet]
        public List<DChampionsPAbilities> GetDChampionsPAbilities()
        {
            return this.ChampionsLogic.GetDChampionsPAbilities();
        }
        [HttpGet]
        public List<MoreThanTwoLanes> GetMoreThanTwoLanes()
        {
            return this.ChampionsLogic.GetMoreThanTwoLanes();
        }
    }
}
