using ConsoleTools;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;

namespace SWZZPI_HFT_2023241.Client
{
    public class Program
    {             
        #region Lists
        static void ListChampions(string champion)
        {
            if (champion == "Champion")
            {
                List<Champions> champions = restService.Get<Champions>("champions");
                Console.WriteLine("Champions: ");
                Console.WriteLine("------------------------");
                foreach (var item in champions)
                {
                    Console.WriteLine("| " + item.Id + ": " + item.Name + " |");
                    Console.WriteLine("------------------------");
                }
            }
            Console.ReadLine();
        }
        static void ListRegions(string region)
        {
            if (region == "Region")
            {
                List<Regions> regions = restService.Get<Regions>("regions");
                Console.WriteLine("Regions: ");
                Console.WriteLine("------------------------");
                foreach (var item in regions)
                {
                    Console.WriteLine("| " + item.Id + ": " + item.Name + " |");
                    Console.WriteLine("------------------------");
                }
            }
            Console.ReadLine();
        }
        static void ListAbilities(string ability)
        {
            if (ability == "Ability")
            {
                List<Abilities> abilities = restService.Get<Abilities>("abilities");
                Console.WriteLine("Abilities: ");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in abilities)
                {
                    Console.WriteLine("| " + item.Id + ": " + item.Name + " |");
                    Console.WriteLine("-------------------------------------------------");
                }
            }
            Console.ReadLine();
        }
        #endregion
        #region Creates
        static void CreateChampions(string champion)
        {
            if (champion == "Champion")
            {
                Console.Write("Enter the champion's name: ");
                string name = Console.ReadLine();
                restService.Post(new Champions() { Name = name }, "champions");
            }
        }
        static void CreateRegions(string region)
        {
            if (region == "Region")
            {
                Console.Write("Enter the region's name: ");
                string name = Console.ReadLine();
                restService.Post(new Regions() { Name = name }, "regions");
            }
        }
        static void CreateAbilities(string ability)
        {
            if (ability == "Ability")
            {
                Console.Write("Enter the ability's name: ");
                string name = Console.ReadLine();
                restService.Post(new Abilities() { Name = name }, "abilities");
            }
        }
        #endregion
        #region Deletes
        static void DeleteChampions(string champion)
        {
            if (champion == "Champion")
            {
                Console.Write("Enter champion's id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "champions");
            }
        }
        static void DeleteRegions(string region)
        {
            if (region == "Region")
            {
                Console.Write("Enter region's id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "regions");
            }
        } 
        static void DeleteAbilities(string ability)
        {
            if (ability == "Ability")
            {
                Console.Write("Enter ability's id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "abilities");
            }
        }
        #endregion
        #region Updates
        static void UpdateChampions(string champion)
        {
            if (champion == "Champion")
            {
                Console.Write("Enter the champion's id: ");
                int oldId = int.Parse(Console.ReadLine());
                Champions old = restService.Get<Champions>(oldId, "champions");
                Console.Write($"Enter the champion's new name (old name: {old.Name}): ");
                string name = Console.ReadLine();
                old.Name = name;
                restService.Put(old, "champions");
            }
        } 
        static void UpdateRegions(string region)
        {
            if (region == "Region")
            {
                Console.Write("Enter the region's id: ");
                int oldId = int.Parse(Console.ReadLine());
                Regions old = restService.Get<Regions>(oldId, "regions");
                Console.Write($"Enter the region's new name (old name: {old.Name}): ");
                string name = Console.ReadLine();
                old.Name = name;
                restService.Put(old, "regions");
            }
        }
        static void UpdateAbilities(string ability)
        {
            if (ability == "Ability")
            {
                Console.Write("Enter the ability's id: ");
                int oldId = int.Parse(Console.ReadLine());
                Abilities old = restService.Get<Abilities>(oldId, "abilities");
                Console.Write($"Enter the ability's new name (old name: {old.Name}): ");
                string name = Console.ReadLine();
                old.Name = name;
                restService.Put(old, "abilities");
            }
        }
        #endregion
        #region Non Cruds
        static void GetShurimaChampions()
        {
            var shurima = restService.Get<ShurimaChampions>("stat/GetShurimaChampionsBetween2012And2016");
            Console.WriteLine("----------------------------------------------");
            foreach (var champion in shurima)
            {
                Console.WriteLine("| Név: " + champion.Name + " | Régió: " + champion.Region + " | Év: " + champion.Year + " |");
                Console.WriteLine("----------------------------------------------");
            }
            Console.ReadLine();
        }
        static void GetFemalesUltimates()
        {
            var ultimates = restService.Get<FemalesUltimates>("stat/GetFemalesUltimates");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in ultimates)
            {
                Console.WriteLine("| Név: " + item.Name + " | Képesség: " + item.AbilityName + " |");
                Console.WriteLine("--------------------------------------------------------");
            }
            Console.ReadLine();
        }
        static void GetAllIonianChampions()
        {
            var ionia = restService.Get<IonianChampions>("stat/GetAllIonianChampions");
            Console.WriteLine("--------------------------------------");
            foreach (var item in ionia)
            {
                Console.WriteLine("| Név: " + item.Name + " | Régió: " + item.Region + " |");
                Console.WriteLine("--------------------------------------");
            }
            Console.ReadLine();
        }
        static void GetDemacianAbilities()
        {
            var demacia = restService.Get<DemacianAbilities>("stat/GetDemacianAbilities");
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach (var item in demacia)
            {
                Console.WriteLine("| Név: " + item.ChampionName + " | Képesség: " + item.Name + " | Típus: " + item.Key + " | Régió: " + item.Region + " |");
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        static void GetDChampionsPAbilities() 
        {
            var dp = restService.Get<DChampionsPAbilities>("stat/GetDChampionsPAbilities");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var item in dp)
            {
                Console.WriteLine("| Név: " + item.Name + " | Típus: " + item.Key + " | Képesség: " + item.KeyName + " |");
                Console.WriteLine("------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        static void GetMoreThanTwoLanes()
        {
            var lanes = restService.Get<MoreThanTwoLanes>("stat/GetMoreThanTwoLanes");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var item in lanes)
            {
                Console.WriteLine("| Név: " + item.Name + " | Ösvény: " + item.Lane + " | Régió: " + item.Region + " |");
                Console.WriteLine("----------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        #endregion
        static RestService restService;
        static void Main(string[] args)
        {
            restService = new RestService("http://localhost:30487/", "swagger");
            var championsMenu = new ConsoleMenu(args, level: 1)
                                .Add("List", () => ListChampions("Champion"))
                                .Add("Create", () => CreateChampions("Champion"))
                                .Add("Delete", () => DeleteChampions("Champion"))
                                .Add("Update", () => UpdateChampions("Champion"))
                                .Add("Exit", ConsoleMenu.Close);
            var regionsMenu = new ConsoleMenu(args, level: 1)
                                .Add("List", () => ListRegions("Region"))
                                .Add("Create", () => CreateRegions("Region"))
                                .Add("Delete", () => DeleteRegions("Region"))
                                .Add("Update", () => UpdateRegions("Region"))
                                .Add("Exit", ConsoleMenu.Close);
            var abilitiesMenu = new ConsoleMenu(args, level: 1)
                                .Add("List", () => ListAbilities("Ability"))
                                .Add("Create", () => CreateAbilities("Ability"))
                                .Add("Delete", () => DeleteAbilities("Ability"))
                                .Add("Update", () => UpdateAbilities("Ability"))
                                .Add("Exit", ConsoleMenu.Close);
            var noncrudMenu = new ConsoleMenu(args, level: 1)
                              .Add("GetShurimaChampions", () => GetShurimaChampions())
                              .Add("GetFemalesUltimates", () => GetFemalesUltimates())
                              .Add("GetAllIonianChampions", () => GetAllIonianChampions())
                              .Add("GetDemacianAbilities", () => GetDemacianAbilities())
                              .Add("GetDChampionsPAbilities", () => GetDChampionsPAbilities())
                              .Add("GetMoreThanTwoLanes", () => GetMoreThanTwoLanes())
                              .Add("Exit", ConsoleMenu.Close);                              
            var menu = new ConsoleMenu(args, level: 0)
                       .Add("Champions", () => championsMenu.Show())
                       .Add("Regions", () => regionsMenu.Show())
                       .Add("Abilities", () => abilitiesMenu.Show())
                       .Add("Non Cruds", () => noncrudMenu.Show())
                       .Add("Exit", ConsoleMenu.Close);
            menu.Show();
           
        }
    }
}
