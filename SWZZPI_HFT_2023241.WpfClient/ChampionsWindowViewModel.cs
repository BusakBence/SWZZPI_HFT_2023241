using Microsoft.Toolkit.Mvvm.ComponentModel;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    public class ChampionsWindowViewModel : ObservableRecipient
    {
        public RestCollection<Champions> Champions { get; set; }
        private Champions selectedChampion;
        public Champions SelectedChampion
        {
            get
            {
                return selectedChampion;
            }
            set
            {
                if (value != null)
                {
                    selectedChampion = new Champions()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Gender = value.Gender,
                        Species = value.Species,
                        Lane = value.Lane,
                        ReleaseYear = value.ReleaseYear,
                        RegionsId = value.RegionsId
                    };
                    OnPropertyChanged();
                }
            }
        }
        public ICommand CreateChampionsCommand { get; set; }
        public ICommand DeleteChampionsCommand { get; set; }
        public ICommand UpdateChampionsCommand { get; set; }
        public ChampionsWindowViewModel()
        {

        }
    }
}
