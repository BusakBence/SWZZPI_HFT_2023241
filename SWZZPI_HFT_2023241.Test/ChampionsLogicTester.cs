using Moq;
using NUnit.Framework;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWZZPI_HFT_2023241.Test
{
    [TestFixture]
    public class ChampionsLogicTester
    {
        ChampionsLogic championsLogic;
        RegionsLogic regionsLogic;
        AbilitiesLogic abilitiesLogic;
        Mock<IRepository<Champions>> mockChampionsRepo;
        Mock<IRepository<Regions>> mockRegionsRepo;
        Mock<IRepository<Abilities>> mockAbilitiesRepo;
        [SetUp]
        public void Init()
        {
            mockChampionsRepo = new Mock<IRepository<Champions>>();
            mockChampionsRepo.Setup(t => t.ReadAll()).Returns(new List<Champions>()
            {
                new Champions("1*Janos*Male*Human*Middle*2011*3"),
                new Champions("2*Jozsef*Male*Demon*Bottom*2009*2"),
                new Champions("3*Rebeka*Female*Yordle*Top*2017*5"),
                new Champions("4*Imre*Male*Vastayan*Support*2021*4*"),
                new Champions("5*Ábel*Male*God*Jungle*2015*1")
            }.AsQueryable);
            mockRegionsRepo = new Mock<IRepository<Regions>>();
            mockRegionsRepo.Setup(x => x.ReadAll()).Returns(new List<Regions>()
            {
                new Regions("1*Shurima*Közép*Közepes*Köztársaság*Kontinentális"),
                new Regions("2*Olaszország*Dél*Magas*Köztársaság*Mediterrán"),
                new Regions("3*Finnország*Észak*Magas*Köztársaság*Tundra"),
                new Regions("4*Portugália*Nyugat*Közepes*Köztársaság*Mediterrán"),
                new Regions("5*Görögország*Kelet*Közepes*Köztársaság*Mediterrán")
            }.AsQueryable);
            mockAbilitiesRepo = new Mock<IRepository<Abilities>>();
            mockAbilitiesRepo.Setup(y => y.ReadAll()).Returns(new List<Abilities>()
            {
                new Abilities("1*Képesség*C*2"),
                new Abilities("2*Remek*U*1"),
                new Abilities("3*Hukk*R*3"),
                new Abilities("4*Pukk*I*5"),
                new Abilities("5*Darum*N*3")
            }.AsQueryable);
            championsLogic = new ChampionsLogic(mockChampionsRepo.Object, mockRegionsRepo.Object, mockAbilitiesRepo.Object);
            regionsLogic = new RegionsLogic(mockRegionsRepo.Object);
            abilitiesLogic = new AbilitiesLogic();
        }
        [Test]
        public void GetShurimaChampionsBetween2012And2016Test()
        {
            var expectedHeroes = new List<ShurimaHeros> { new ShurimaHeros() { Name = "Ábel", Region = "Shurima", Year = 2015 } };
            var actualHeroes = championsLogic.GetShurimaChampionsBetween2012And2016();
            CollectionAssert.AreEqual(expectedHeroes, actualHeroes);
        }
        [Test]
        public void GetFemalesUltimatesTest()
        {
            var expectedUltimates = new List<FemalesUltimates> { new FemalesUltimates() { Name = "Rebeka", AbilityName = "Hukk" } };
            var actualUltimates = championsLogic.GetFemalesUltimates();
            CollectionAssert.AreEqual(expectedUltimates, actualUltimates);
        }
    }
}
