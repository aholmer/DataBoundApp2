using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DataBoundApp2.Resources;
using DataBoundApp2.ViewModels;
using DataBoundApp2.Models;
using System.Threading;
using System.Windows.Threading;

namespace DataBoundApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Dispatcher Timer
        System.Windows.Threading.DispatcherTimer dt;

        // GUI updated every milisecond of this value
        int TimePerUpdate = 1000;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;
            CurrentTemperatureViewOnPage.DataContext = App.ViewModel;

            // Timer for updating
            dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, TimePerUpdate);
            dt.Tick += new EventHandler(DtTick);
        }

        private void DtTick(object sender, EventArgs e)
        {
            App.ViewModel.LoadData();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            dt.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dt.Stop();
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as KelvinItem).Id, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void NewestButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainLongListSelector.Visibility == Visibility.Visible)
                MainLongListSelector.Visibility = Visibility.Collapsed;
            else
                MainLongListSelector.Visibility = Visibility.Visible;
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/OptionsView.xaml", UriKind.Relative));
        }
    }
}