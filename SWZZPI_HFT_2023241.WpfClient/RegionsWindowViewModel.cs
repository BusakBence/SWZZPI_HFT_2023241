using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SWZZPI_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    class RegionsWindowViewModel : ObservableRecipient
    {
        public RestCollection<Regions> Regions { get; set; }
        private Regions selectedRegion;
        public Regions SelectedRegion
        {
            get
            {
                return selectedRegion;
            }
            set
            {
                if (value != null)
                {
                    selectedRegion = new Regions()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Location = value.Location,
                        Environment = value.Environment,
                        TechnologyLevel = value.TechnologyLevel,
                        FormOfGovernment = value.FormOfGovernment
                    };
                    OnPropertyChanged();
                    (DeleteRegionsCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateRegionsCommand { get; set; }
        public ICommand DeleteRegionsCommand { get; set; }
        public ICommand UpdateRegionsCommand { get; set; }
        public RegionsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Regions = new RestCollection<Regions>("http://localhost:30487/", "Regions", "hub");
                CreateRegionsCommand = new RelayCommand(() =>
                {
                    Regions.Add(new Regions()
                    {
                        Id = SelectedRegion.Id,
                        Name = SelectedRegion.Name,
                        Location = SelectedRegion.Location,
                        Environment = SelectedRegion.Environment,
                        TechnologyLevel = SelectedRegion.TechnologyLevel,
                        FormOfGovernment = SelectedRegion.FormOfGovernment
                    });
                });
                DeleteRegionsCommand = new RelayCommand(() =>
                {
                    Regions.Delete(SelectedRegion.Id);
                },
                () =>
                {
                    return SelectedRegion != null;
                });
                UpdateRegionsCommand = new RelayCommand(() =>
                {
                    Regions.Update(SelectedRegion);
                });
                SelectedRegion = new Regions()
                {
                    Id = 0,
                    Name = "",
                    Location = "",
                    Environment = "",
                    TechnologyLevel = "",
                    FormOfGovernment = ""
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
