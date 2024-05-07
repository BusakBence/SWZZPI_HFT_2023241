using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    class AbilitiesWindowViewModel : ObservableRecipient
    {
        public RestCollection<Abilities> Abilities { get; set; }
        private Abilities selectedAbilities;
        public Abilities SelectedAbilities
        {
            get
            {
                return selectedAbilities;
            }
            set
            {
                if (value != null)
                {
                    selectedAbilities = new Abilities()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        AbilityKey = value.AbilityKey,
                        Champion = value.Champion
                    };
                    OnPropertyChanged();
                    (DeleteAbilitiesCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateAbilitiesCommand { get; set; }
        public ICommand DeleteAbilitiesCommand { get; set; }
        public ICommand UpdateAbilitiesCommand { get; set; }
        public AbilitiesWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Abilities = new RestCollection<Abilities>("http://localhost:30487/", "Abilities", "hub");
                CreateAbilitiesCommand = new RelayCommand(() =>
                {
                    Abilities.Add(new Abilities()
                    {
                        Id = SelectedAbilities.Id,
                        Name = SelectedAbilities.Name,
                        AbilityKey = SelectedAbilities.AbilityKey,
                        Champion = SelectedAbilities.Champion
                    });
                });
                DeleteAbilitiesCommand = new RelayCommand(() =>
                {
                    Abilities.Delete(SelectedAbilities.Id);
                },
                () =>
                {
                    return SelectedAbilities != null;
                });
                UpdateAbilitiesCommand = new RelayCommand(() =>
                {
                    Abilities.Update(SelectedAbilities);
                });
                SelectedAbilities = new Abilities()
                {
                    Id = 0,
                    Name = "",
                    AbilityKey = ' '
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
