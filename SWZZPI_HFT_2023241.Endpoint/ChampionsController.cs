using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        public IHubContext<SignalRHub> hub;
        public ChampionsController(IChampionsLogic championsLogic, IHubContext<SignalRHub> hub)
        {
            this.ChampionsLogic = championsLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ChampionsCreated", champion);
        }        
        [HttpPut]
        public void Update([FromBody] Champions champion)
        {
            this.ChampionsLogic.Update(champion);
            this.hub.Clients.All.SendAsync("ChampionsUpdated", champion);
        }      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var championtoDelete = this.ChampionsLogic.Read(id);
            this.ChampionsLogic.Delete(id);
            this.hub.Clients.All.SendAsync("ChampionsDeleted", championtoDelete);
        }
    }
}
