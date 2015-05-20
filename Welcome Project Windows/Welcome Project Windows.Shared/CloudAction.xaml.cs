using FHSDK;
using System;
using System.ComponentModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Welcome_Project_Windows
{
    public sealed partial class CloudAction : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Message { get; set; }
        
        public CloudAction()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        private async void Call_Cloud(object sender, RoutedEventArgs e)
        {
            Message = "Error";
            FHResponse res = await FH.Cloud("hello", "POST", null, null);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Message = (string)res.GetResponseAsDictionary()["text"];
            }

            PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            result.Visibility = Visibility.Visible;
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
