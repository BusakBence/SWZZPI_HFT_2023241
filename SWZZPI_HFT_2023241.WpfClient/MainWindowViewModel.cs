using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public static RestService restService;
        public ICommand ChampionsWindowCommand { get; set; }
        public ICommand RegionsWindowCommand { get; set; }
        public ICommand AbilitiesWindowCommand { get; set; }
        public ICommand NonCrudsWindowCommand { get; set; }
        public MainWindowViewModel()
        {
            restService = new RestService("http://localhost:30487/", "swagger");
            ChampionsWindowCommand = new RelayCommand(() =>
            {
                ChampionsWindow championsWindow = new ChampionsWindow();
                championsWindow.Show();
            });
            RegionsWindowCommand = new RelayCommand(() =>
            {
                RegionsWindow regionsWindow = new RegionsWindow();
                regionsWindow.Show();
            });
            AbilitiesWindowCommand = new RelayCommand(() =>
            {
                AbilitiesWindow abilitiesWindow = new AbilitiesWindow();
                abilitiesWindow.Show();
            });
            NonCrudsWindowCommand = new RelayCommand(() =>
            {
                NonCrudsWindow nonCrudsWindow = new NonCrudsWindow();
                nonCrudsWindow.Show();
            });
        }
    }
}
