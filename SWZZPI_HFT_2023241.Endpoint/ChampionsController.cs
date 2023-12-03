using Microsoft.AspNetCore.Mvc;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SWZZPI_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        public IChampionsLogic ChampionsLogic;
        public ChampionsController(IChampionsLogic championsLogic)
        {
            this.ChampionsLogic = championsLogic;
        }     
        [HttpGet]
        public IEnumerable<Champions> ReadAll()
        {
            return this.ChampionsLogic.ReadAll();
        }       
        [HttpGet("{id}")]
        public Champions Read(int id)
        {
            return this.ChampionsLogic.Read(id);
        }      
        [HttpPost]
        public void Create([FromBody] Champions champion)
        {
            this.ChampionsLogic.Create(champion);
        }        
        [HttpPut]
        public void Update([FromBody] Champions champion)
        {
            this.ChampionsLogic.Update(champion);
        }      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.ChampionsLogic.Delete(id);
        }
    }
}
