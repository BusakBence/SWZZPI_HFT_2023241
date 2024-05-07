using Microsoft.Toolkit.Mvvm.ComponentModel;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZZPI_HFT_2023241.WpfClient
{
    class NonCrudsWindowViewModel : ObservableRecipient
    {
        private ObservableCollection<ShurimaChampions> shurimaChampions { get; set; }
        public ObservableCollection<ShurimaChampions> ShurimaChampions
        {
            get
            {
                return shurimaChampions;
            }
            set
            {
                shurimaChampions = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<FemalesUltimates> femalesUltimates { get; set; }
        public ObservableCollection<FemalesUltimates> FemalesUltimates
        {
            get
            {
                return femalesUltimates;
            }
            set
            {
                femalesUltimates = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<IonianChampions> ionianChampions { get; set; }
        public ObservableCollection<IonianChampions> IonianChampions
        {
            get
            {
                return ionianChampions;
            }
            set
            {
                IonianChampions = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<DemacianAbilities> demacianAbilities { get; set; }
        public ObservableCollection<DemacianAbilities> DemacianAbilities
        {
            get
            {
                return demacianAbilities;
            }
            set
            {
                demacianAbilities = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<DChampionsPAbilities> dChampionspAbilities { get; set; }
        public ObservableCollection<DChampionsPAbilities> DChampionsPAbilities
        {
            get
            {
                return dChampionspAbilities;
            }
            set
            {
                dChampionspAbilities = value;
                OnPropertyChanged();
            }
        }

    }
}
