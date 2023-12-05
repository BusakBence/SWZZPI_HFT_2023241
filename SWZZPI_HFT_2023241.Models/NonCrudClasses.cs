using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZZPI_HFT_2023241.Models
{   
        public class ShurimaChampions
        {
            public string Name { get; set; }
            public string Region { get; set; }
            public int Year { get; set; }
            public override bool Equals(object obj)
            {
                ShurimaChampions b = obj as ShurimaChampions;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name && this.Region == b.Region && this.Year == b.Year;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.Region, this.Year);
            }
        }
        public class FemalesUltimates
        {
            public string Name { get; set; }
            public string AbilityName { get; set; }
            public override bool Equals(object obj)
            {
                FemalesUltimates b = obj as FemalesUltimates;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name && this.AbilityName == b.AbilityName;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.AbilityName);
            }
        }
    public class IonianChampions
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public override bool Equals(object obj)
        {
            IonianChampions b = obj as IonianChampions;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.Region == b.Region;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Region);
        }
    }
        public class DemacianAbilities
        {
            public string ChampionName { get; set; }
            public string Name { get; set; }
            public char Key { get; set; }
            public string Region { get; set; }
            public override bool Equals(object obj)
            {
                DemacianAbilities b = obj as DemacianAbilities;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.ChampionName == b.ChampionName && this.Name == b.Name && this.Key == b.Key && this.Region == b.Region;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ChampionName, this.Name, this.Key, this.Region);
            }
        }
        public class DChampionsPAbilities
        {
            public string Name { get; set; }
            public char Key { get; set; }
            public string KeyName { get; set; }
            public override bool Equals(object obj)
            {
                DChampionsPAbilities b = obj as DChampionsPAbilities;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == b.Name && this.Key == b.Key && this.KeyName == b.KeyName;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.Key, this.KeyName);
            }
        }
    public class MoreThanTwoLanes
    {
        public string Name { get; set; }
        public string Lane { get; set; }
        public string Region { get; set; }
        public override bool Equals(object obj)
        {
            MoreThanTwoLanes b = obj as MoreThanTwoLanes;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name && this.Lane == b.Lane && this.Region == b.Region;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Lane, this.Region);
        }
    }
}
