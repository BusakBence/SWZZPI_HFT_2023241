using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SWZZPI_HFT_2023241.WpfClient
{
    public class NonCrudsWindowViewModel : ObservableRecipient
    {

        public ObservableCollection<ShurimaChampions> shurimaChampionsBetween2012And2016 { get; set; }
        public ObservableCollection<ShurimaChampions> ShurimaChampionsBetween2012And2016
        {
            get { return shurimaChampionsBetween2012And2016; }
            set
            {
                shurimaChampionsBetween2012And2016 = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FemalesUltimates> femalesUltimates { get; set; }
        public ObservableCollection<FemalesUltimates> FemalesUltimates
        {
            get { return femalesUltimates; }
            set
            {
                femalesUltimates = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IonianChampions> allIonianChampions { get; set; }
        public ObservableCollection<IonianChampions> AllIonianChampions
        {
            get { return allIonianChampions; }
            set
            {
                allIonianChampions = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DemacianAbilities> demacianAbilities { get; set; }
        public ObservableCollection<DemacianAbilities> DemacianAbilities
        {
            get { return demacianAbilities; }
            set
            {
                demacianAbilities = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DChampionsPAbilities> dChampionsPAbilities { get; set; }
        public ObservableCollection<DChampionsPAbilities> DChampionsPAbilities
        {
            get { return dChampionsPAbilities; }
            set
            {
                dChampionsPAbilities = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MoreThanTwoLanes> moreThanTwoLanes { get; set; }
        public ObservableCollection<MoreThanTwoLanes> MoreThanTwoLanes
        {
            get { return moreThanTwoLanes; }
            set
            {
                moreThanTwoLanes = value;
                OnPropertyChanged();
            }
        }


        public RestService rest;
        private string tb_input;
        public string TB_input
        {
            get
            {
                return tb_input;
            }
            set
            {
                tb_input = value;
                OnPropertyChanged();
                (GetShurimaChampionsBetween2012And2016Command as RelayCommand).NotifyCanExecuteChanged();
                (GetFemalesUltimatesCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetAllIonianChampionsCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetDemacianAbilitiesCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetDChampionsPAbilitiesCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        private string selectedMethod;
        public string SelectedMethod
        {
            get { return selectedMethod; }
            set
            {
                selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
                OnPropertyChanged(nameof(SelectedObservableCollection));
            }
        }

        public IEnumerable SelectedObservableCollection
        {
            get
            {
                switch (SelectedMethod)
                {
                    case "ShurimaChamionsBetween2012And2016":
                        return ShurimaChampionsBetween2012And2016;
                    case "FemalesUltimates":
                        return FemalesUltimates;
                    case "AllIonianChampions":
                        return AllIonianChampions;
                    case "DemacianAbilities":
                        return DemacianAbilities;
                    case "DChampionsPAbilities":
                        return DChampionsPAbilities;
                    case "MoreThanTwoLanes":
                        return MoreThanTwoLanes;
                    default:
                        return null;
                }
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

        public ICommand GetShurimaChampionsBetween2012And2016Command { get; set; }
        public ICommand GetFemalesUltimatesCommand { get; set; }
        public ICommand GetAllIonianChampionsCommand { get; set; }
        public ICommand GetDemacianAbilitiesCommand { get; set; }
        public ICommand GetDChampionsPAbilitiesCommand { get; set; }
        public ICommand GetMoreThanTwoLanesCommand { get; set; }


        public NonCrudsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = MainWindowViewModel.restService;
                GetShurimaChampionsBetween2012And2016Command = new RelayCommand(() =>
                {
                    var a = rest.Get<ShurimaChampions>($"http://localhost:30487/Stat/GetShurimaChampionsBetween2012And2016");
                    ShurimaChampionsBetween2012And2016 = new ObservableCollection<ShurimaChampions>(a);
                    SelectedMethod = "ShurimaChampionsBetween2012And2016";
                });
                GetFemalesUltimatesCommand = new RelayCommand(() =>
                {
                    var a = rest.Get<FemalesUltimates>($"http://localhost:30487/Stat/GetFemalesUltimates");
                    FemalesUltimates = new ObservableCollection<FemalesUltimates>(a);
                    SelectedMethod = "FemalesUltimates";

                    ;
                });
                GetAllIonianChampionsCommand = new RelayCommand(() =>
                {
                    var a = rest.Get<IonianChampions>($"http://localhost:30487/Stat/GetAllIonianChampions");
                    AllIonianChampions = new ObservableCollection<IonianChampions>(a);
                    SelectedMethod = "AllIonianChampions";
                });
                GetDemacianAbilitiesCommand = new RelayCommand(() =>
                {
                    var a = rest.Get<DemacianAbilities>($"http://localhost:30487/Stat/GetDemacianAbilities");
                    DemacianAbilities = new ObservableCollection<DemacianAbilities>(a);
                    SelectedMethod = "DemacianAbilities";
                });

                GetDChampionsPAbilitiesCommand = new RelayCommand(() =>
                {
                    var a = rest.Get<DChampionsPAbilities>($"http://localhost:30487/Stat/GetDChampionsPAbilities");
                    DChampionsPAbilities = new ObservableCollection<DChampionsPAbilities>(a);
                    SelectedMethod = "DChampionsPAbilities";
                }); 
                GetMoreThanTwoLanesCommand = new RelayCommand(() =>
                {
                    var a = rest.Get<MoreThanTwoLanes>($"http://localhost:30487/Stat/GetMoreThanTwoLanes");
                    MoreThanTwoLanes = new ObservableCollection<MoreThanTwoLanes>(a);
                    SelectedMethod = "MoreThanTwoLanes";
                });
            }
        }
    }
}
