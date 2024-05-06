using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
            ChampionsWindowCommand = new RelayCommand(() =>
            {

            });
            RegionsWindowCommand = new RelayCommand(() =>
            {

            });
            AbilitiesWindowCommand = new RelayCommand(() =>
            {

            });
            NonCrudsWindowCommand = new RelayCommand(() =>
            {

            });
        }
    }
}
