using Microsoft.AspNetCore.Mvc;
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
        public RegionsController(IRegionsLogic regionsLogic)
        {
            this.RegionsLogic = regionsLogic;
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
        }
        [HttpPut]
        public void Update([FromBody] Regions region)
        {
            this.RegionsLogic.Update(region);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.RegionsLogic.Delete(id);
        }
    }
}
