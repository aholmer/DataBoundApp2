using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DataBoundApp2.Views
{
    public partial class OptionsView : PhoneApplicationPage
    {
        public OptionsView()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            switch (App.Temperature)
            {
                case "fahrenheit":
                    CheckBoxFahrenheit.IsChecked = true;
                    break;
                case "kelvin":
                    CheckBoxKelvin.IsChecked = true;
                    break;
                case "celcius":
                    CheckBoxCelcius.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        public void CelciusChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxCelcius.IsChecked = true;
            App.Temperature = "celcius";
        }

        public void FahrenheitChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxFahrenheit.IsChecked = true;
            App.Temperature = "fahrenheit";
        }

        public void KelvinChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxKelvin.IsChecked = true;
            App.Temperature = "kelvin";
        }
    }
}