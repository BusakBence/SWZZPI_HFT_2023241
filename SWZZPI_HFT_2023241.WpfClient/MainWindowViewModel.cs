using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        static RestService restService;
        public ICommand ChampionsWindowCommand;
        public ICommand RegionsWindowCommand;
        public ICommand AbilitiesWindowCommand;
        public ICommand NonCrudsWindowCommand;
        public MainWindowViewModel()
        {
            restService = new RestService("http://localhost:30487/", "swagger");

        }
    }
}
