using SWZZPI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SWZZPI_HFT_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for NonCrudsWindow.xaml
    /// </summary>
    public partial class NonCrudsWindow : Window
    {
        public NonCrudsWindow()
        {
            InitializeComponent();
        }
    }
    public class MyItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ShurimaChampionsBetween2012And2016 { get; set; }
        public DataTemplate FemalesUltimates { get; set; }
        public DataTemplate AllIonianChampions { get; set; }
        public DataTemplate DemacianAbilities { get; set; }
        public DataTemplate DChampionsPAbilities { get; set; }
        public DataTemplate MoreThanTwoLanes { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ShurimaChampions)
                return ShurimaChampionsBetween2012And2016;
            if (item is FemalesUltimates)
                return FemalesUltimates;
            if (item is IonianChampions)
                return AllIonianChampions;
            if (item is DemacianAbilities)
                return DemacianAbilities;
            if (item is DChampionsPAbilities)
                return DChampionsPAbilities;
            if (item is MoreThanTwoLanes)
                return MoreThanTwoLanes;

            return base.SelectTemplate(item, container);
        }
    }
}
