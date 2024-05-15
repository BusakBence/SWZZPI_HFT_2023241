using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SWZZPI_HFT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        public IAbilitiesLogic AbilitiesLogic;
        public IHubContext<SignalRHub> hub;
        public AbilitiesController(IAbilitiesLogic abilitiesLogic, IHubContext<SignalRHub> hub)
        {
            this.AbilitiesLogic = abilitiesLogic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Abilities> ReadAll()
        {
            return this.AbilitiesLogic.ReadAll();
        }
        [HttpGet("{id}")]
        public Abilities Read(int id)
        {
            return this.AbilitiesLogic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Abilities ability)
        {
            this.AbilitiesLogic.Create(ability);
            this.hub.Clients.All.SendAsync("AbilitiesCreated", ability);
        }
        [HttpPut]
        public void Update([FromBody] Abilities ability)
        {
            this.AbilitiesLogic.Update(ability);
            this.hub.Clients.All.SendAsync("AbilitiesUpdated", ability);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var abilitytoDelete = this.AbilitiesLogic.Read(id);
            this.AbilitiesLogic.Delete(id);
            this.hub.Clients.All.SendAsync("AbilitiesDeleted", abilitytoDelete);
        }
    }
}
