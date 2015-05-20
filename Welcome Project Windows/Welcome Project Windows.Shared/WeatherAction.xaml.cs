using FHSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Welcome_Project_Windows
{
    public sealed partial class WeatherAction : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Geoposition geoposition;
        public string Message { get; set; }
        public ObservableCollection<Weather> WeatherData { get; set; }

        public WeatherAction()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        private async void Location(object sender, RoutedEventArgs e)
        {
            Message = "Error";
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 10;

            geoposition = await geolocator.GetGeopositionAsync();
            Message = String.Format("lat= {0}; lon= {1}", geoposition.Coordinate.Point.Position.Latitude, geoposition.Coordinate.Point.Position.Longitude);

            PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            result.Visibility = Visibility.Visible;
        }

        private async void Call_Cloud(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> data = new Dictionary<string, object>() {
                { "lat", geoposition.Coordinate.Point.Position.Latitude },
                { "lon", geoposition.Coordinate.Point.Position.Longitude }
            };

            FHResponse res = await FH.Cloud("getWeather", "POST", null, data);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                WeatherData = new ObservableCollection<Weather>();
                var array = ((JArray)res.GetResponseAsDictionary()["data"]);
                foreach (var weather in array)
                {
                    WeatherData.Add(weather.ToObject<Weather>());
                }
            }

            PropertyChanged(this, new PropertyChangedEventArgs("WeatherData"));
        }

        public class Weather
        {
            public string icon { get; set; }
            public string date { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string desc { get; set; }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
