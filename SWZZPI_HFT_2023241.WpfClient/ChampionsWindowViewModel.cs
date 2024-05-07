using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SWZZPI_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
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
                        Region = value.Region
                    };
                    OnPropertyChanged();
                    (DeleteChampionsCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateChampionsCommand { get; set; }
        public ICommand DeleteChampionsCommand { get; set; }
        public ICommand UpdateChampionsCommand { get; set; }
        public ChampionsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Champions = new RestCollection<Champions>("http://localhost:30487/", "Champions", "hub");
                CreateChampionsCommand = new RelayCommand(() =>
                {
                    Champions.Add(new Champions()
                    {
                        Id = SelectedChampion.Id,
                        Name = SelectedChampion.Name,
                        Gender = SelectedChampion.Gender,
                        Species = SelectedChampion.Species,
                        Lane = SelectedChampion.Lane,
                        ReleaseYear = SelectedChampion.ReleaseYear,
                        Region = SelectedChampion.Region
                    });
                });
                DeleteChampionsCommand = new RelayCommand(() =>
                {
                    Champions.Delete(SelectedChampion.Id);
                },
                () =>
                {
                    return SelectedChampion != null;
                });
                UpdateChampionsCommand = new RelayCommand(() =>
                {
                    Champions.Update(SelectedChampion);
                });
                SelectedChampion = new Champions()
                {
                    Id = int.MaxValue,
                    Name = "",
                    Gender = "",
                    Species = "",
                    Lane = "",
                    ReleaseYear = 2024
                };
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
