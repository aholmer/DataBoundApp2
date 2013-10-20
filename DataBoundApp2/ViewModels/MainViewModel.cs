using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DataBoundApp2.Resources;
using DataBoundApp2.Models;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using System.Windows;

namespace DataBoundApp2.ViewModels
{
    public class MainViewModel : BaseINPC
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<KelvinItem>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        private ObservableCollection<KelvinItem> _Items;
        public ObservableCollection<KelvinItem> Items
        {
            get { return _Items; }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        private KelvinItem _NewestItem;
        public KelvinItem NewestItem
        {
            get { return _NewestItem; }
            set
            {
                if (value != _NewestItem)
                {
                    _NewestItem = value;
                    OnPropertyChanged("NewestItem");
                }
            }
        }

        public IEnumerable<KelvinItem> remoteItems { get; set; }
        private IMobileServiceTable<KelvinItem> kelvinTable = App.MobileService.GetTable<KelvinItem>();

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    OnPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {
            remoteItems = await kelvinTable.OrderByDescending(x => x.CreatedAt).Take(5).ToEnumerableAsync();
            ObservableCollection<KelvinItem> temporaryItems = new ObservableCollection<KelvinItem>();
            
            foreach (KelvinItem _kelvinItem in remoteItems)
            {
                KelvinItem item = new KelvinItem()
                {
                    Id = _kelvinItem.Id,
                    Temperature = _kelvinItem.Temperature,
                    CreatedAt = _kelvinItem.CreatedAt
                };

                temporaryItems.Add(item);
            }
            this.Items = temporaryItems;
            
            // Save the most recently added item
            using (IEnumerator<KelvinItem> enumerator = remoteItems.GetEnumerator())
            {
                if (enumerator.MoveNext()) 
                    this.NewestItem = enumerator.Current;
            }

            this.IsDataLoaded = true;
        }
    }
}