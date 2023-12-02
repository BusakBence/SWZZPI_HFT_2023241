﻿using ConsoleTools;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;

namespace SWZZPI_HFT_2023241.Client
{
    class Program
    {
        static RestService restService;
        #region Lists
        static void ListChampions(string champion)
        {
            if (champion == "Champion")
            {
                List<Champions> champions = restService.Get<Champions>("champion");
                foreach (var item in champions)
                {
                    Console.WriteLine(item.Id + "" + item.Name);
                }
            }
        }
        static void ListRegions(string region)
        {
            if (region == "Region")
            {
                List<Regions> regions = restService.Get<Regions>("region");
                foreach (var item in regions)
                {
                    Console.WriteLine(item.Id + "" + item.Name);
                }
            }
        }
        static void ListAbilities(string ability)
        {
            if (ability == "Ability")
            {
                List<Abilities> abilities = restService.Get<Abilities>("ability");
                foreach (var item in abilities)
                {
                    Console.WriteLine(item.Id + "" + item.Name);
                }
            }
        }
        #endregion
        #region Creates
        static void CreateChampions(string champion)
        {
            if (champion == "Champion")
            {
                Console.Write("Enter the champion's name: ");
                string name = Console.ReadLine();
                restService.Post(new Champions() { Name = name }, "champion");
            }
        }
        static void CreateRegions(string region)
        {
            if (region == "Region")
            {
                Console.Write("Enter the region's name: ");
                string name = Console.ReadLine();
                restService.Post(new Regions() { Name = name }, "region");
            }
        }
        static void CreateAbilities(string ability)
        {
            if (ability == "Ability")
            {
                Console.Write("Enter the ability's name: ");
                string name = Console.ReadLine();
                restService.Post(new Abilities() { Name = name }, "ability");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            restService = new RestService("http://localhost:30487/");           
        }
    }
}
