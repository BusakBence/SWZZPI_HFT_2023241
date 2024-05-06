using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWZZPI_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public IRegionsLogic RegionsLogic;
        public IHubContext<SignalRHub> hub;
        public RegionsController(IRegionsLogic regionsLogic, IHubContext<SignalRHub> hub)
        {
            this.RegionsLogic = regionsLogic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Regions> ReadAll()
        {
            return this.RegionsLogic.ReadAll();
        }
        [HttpGet("{id}")]
        public Regions Read(int id)
        {
            return this.RegionsLogic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Regions region)
        {
            this.RegionsLogic.Create(region);
            this.hub.Clients.All.SendAsync("RegionCreated", region);
        }
        [HttpPut]
        public void Update([FromBody] Regions region)
        {
            this.RegionsLogic.Update(region);
            this.hub.Clients.All.SendAsync("RegionUpdated", region);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var regiontoDelete = this.RegionsLogic.Read(id);
            this.RegionsLogic.Delete(id);
            this.hub.Clients.All.SendAsync("RegionCreated", regiontoDelete);
        }
    }
}
