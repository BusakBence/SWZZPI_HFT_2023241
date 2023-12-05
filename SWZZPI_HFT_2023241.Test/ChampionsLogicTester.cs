using Moq;
using NUnit.Framework;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SWZZPI_HFT_2023241.Test
{
    [TestFixture]
    public class ChampionsLogicTester
    {
        ChampionsLogic championsLogic;
        Mock<IRepository<Champions>> mockChampionsRepo;
        Mock<IRepository<Regions>> mockRegionsRepo;
        Mock<IRepository<Abilities>> mockAbilitiesRepo;
        [SetUp]
        public void Init()
        {
            mockChampionsRepo = new Mock<IRepository<Champions>>();
            mockChampionsRepo.Setup(t => t.ReadAll()).Returns(new List<Champions>()
            {
                
                new Champions() { Id = 1, Name = "Janos", Gender = "Male", Species = "Human", Lane = "Middle", ReleaseYear = 2011, RegionsId = 3},
                new Champions() { Id = 2, Name = "Daniel", Gender = "Male", Species = "Demon", Lane = "Bottom", ReleaseYear = 2009, RegionsId = 2},
                new Champions() { Id = 3, Name = "Rebeka", Gender = "Female", Species = "Yordle", Lane = "Top", ReleaseYear = 2017, RegionsId = 5},
                new Champions() { Id = 4, Name = "Imre", Gender = "Male", Species = "Vastayan", Lane = "Support", ReleaseYear = 2021, RegionsId = 4},
                new Champions() { Id = 5, Name = "Abel", Gender = "Male", Species = "God", Lane = "Jungle", ReleaseYear = 2015, RegionsId = 1},               
            }.AsQueryable());
            mockRegionsRepo = new Mock<IRepository<Regions>>();
            mockRegionsRepo.Setup(x => x.ReadAll()).Returns(new List<Regions>()
            {
                new Regions() {Id = 1, Name = "Shurima", Location = "Közép", TechnologyLevel = "Közepes", FormOfGovernment = "Köztársaság", Environment = "Kontinentális" },
                new Regions() {Id = 2, Name = "Noxus", Location = "Dél", TechnologyLevel = "Magas", FormOfGovernment = "Köztársaság", Environment = "Kontinentális" },
                new Regions() {Id = 3, Name = "Ionia", Location = "Észak", TechnologyLevel = "Magas", FormOfGovernment = "Köztársaság", Environment = "Kontinentális" },
                new Regions() {Id = 4, Name = "Demacia", Location = "Nyugat", TechnologyLevel = "Közepes", FormOfGovernment = "Köztársaság", Environment = "Kontinentális" },
                new Regions() {Id = 5, Name = "Freljord", Location = "Kelet", TechnologyLevel = "Közepes", FormOfGovernment = "Köztársaság", Environment = "Kontinentális" },                
            }.AsQueryable());
            mockAbilitiesRepo = new Mock<IRepository<Abilities>>();
            mockAbilitiesRepo.Setup(y => y.ReadAll()).Returns(new List<Abilities>()
            {
                new Abilities() { Id = 1, Name = "Kepesseg", AbilityKey = 'P', ChampionId = 2 },
                new Abilities() { Id = 2, Name = "Remek", AbilityKey = 'Q', ChampionId = 1 },
                new Abilities() { Id = 3, Name = "Hukk", AbilityKey = 'R', ChampionId = 3 },
                new Abilities() { Id = 4, Name = "Pukk", AbilityKey = 'E', ChampionId = 5 },
                new Abilities() { Id = 5, Name = "Darum", AbilityKey = 'W', ChampionId = 4 },
                
            }.AsQueryable());
            foreach (var champion in mockChampionsRepo.Object.ReadAll())
            {
                foreach (var ability in mockAbilitiesRepo.Object.ReadAll())
                {
                    if (champion.Id == ability.ChampionId)
                    {
                        champion.Abilities.Add(ability);
                    }
                }
            }
            foreach (var region in mockRegionsRepo.Object.ReadAll())
            {
                foreach (var champion in mockChampionsRepo.Object.ReadAll())
                {
                    if (region.Id == champion.RegionsId)
                    {
                        region.Champions.Add(champion);
                    }
                }
            }
            foreach (var champion in mockChampionsRepo.Object.ReadAll())
            {
                foreach (var region  in mockRegionsRepo.Object.ReadAll())
                {
                    if (champion.RegionsId == region.Id)
                    {
                        champion.Region = region;
                    }
                }
            }   
            foreach (var ability in mockAbilitiesRepo.Object.ReadAll())
            {
                foreach (var champion  in mockChampionsRepo.Object.ReadAll())
                {
                    if (ability.ChampionId == champion.Id)
                    {
                        ability.Champion = champion;
                    }
                }
            }
            championsLogic = new ChampionsLogic(mockChampionsRepo.Object, mockRegionsRepo.Object, mockAbilitiesRepo.Object);          
        }
        [Test]
        public void GetShurimaChampionsBetween2012And2016Test()
        {
             var expectedHeroes = new List<ShurimaChampions> { new ShurimaChampions() { Name = "Abel", Region = "Shurima", Year = 2015 } };
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
        [Test]
        public void GetAllIonianChampionsTest()
        {
            var expectedIonians = new List<IonianChampions> { new IonianChampions() { Name = "Janos", Region = "Ionia" } };
            var actualIonians = championsLogic.GetAllIonianChampions();
            CollectionAssert.AreEqual(expectedIonians, actualIonians);
        }
        [Test]
        public void GetDemacianAbilitiesTest()
        {
            var expectedAbilities = new List<DemacianAbilities> { new DemacianAbilities() {  ChampionName = "Imre", Name = "Darum", Key = 'W', Region = "Demacia" } };
            var actualAbilities = championsLogic.GetDemacianAbilities();
            CollectionAssert.AreEqual(expectedAbilities, actualAbilities);
        }
        [Test]
        public void GetDChampionsPAbilitiesTest()
        {
            var expectedPAbilities = new List<DChampionsPAbilities> { new DChampionsPAbilities() { Name = "Daniel", Key = 'P', KeyName = "Kepesseg" } };
            var actualPAbilities = championsLogic.GetDChampionsPAbilities();
            CollectionAssert.AreEqual(expectedPAbilities, actualPAbilities);
        }     
    }   
}
