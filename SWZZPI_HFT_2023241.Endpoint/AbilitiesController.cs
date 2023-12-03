using Microsoft.AspNetCore.Mvc;
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
        public AbilitiesController(IAbilitiesLogic abilitiesLogic)
        {
            this.AbilitiesLogic = abilitiesLogic;
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
        }
        [HttpPut]
        public void Update([FromBody] Abilities ability)
        {
            this.AbilitiesLogic.Update(ability);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.AbilitiesLogic.Delete(id);
        }
    }
}
