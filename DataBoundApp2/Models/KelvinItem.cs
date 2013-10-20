using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBoundApp2.Models
{
    public class KelvinItem : BaseINPC
    {
        private int _Id;
        [JsonProperty(PropertyName = "id")]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private double _Temperature;
        [JsonProperty(PropertyName = "temperature")]
        public double Temperature
        {
            get 
            {
                return _Temperature;
            }
            set
            {
                if (value != _Temperature)
                {
                    _Temperature = value;
                    OnPropertyChanged("Temperature");
                }
            }
        }

        private DateTime? _CreatedAt;
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime? CreatedAt
        {
            get { return _CreatedAt; }
            set
            {
                if (value != _CreatedAt)
                {
                    _CreatedAt = value;
                    OnPropertyChanged("CreatedAt");
                }
            }
        }
    }
}
