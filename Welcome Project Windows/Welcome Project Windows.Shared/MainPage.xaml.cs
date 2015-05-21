using FHSDK81.Phone;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitApp();
            DisplayInformation.GetForCurrentView().OrientationChanged += OrientationChanged;
        }

        private async void InitApp()
        {
            await FHClient.Init();
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            OrientationChanged(DisplayInformation.GetForCurrentView(), null);            
        }

        partial void OrientationChanged(DisplayInformation info, object sender);

        private void Cloud_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(CloudAction));
        }

        private void Data_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DataAction));
        }

        private void Node_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(NodeAction));
        }

        private void Integration_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(IntegrationAction));
        }

        private void Example_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(WeatherAction));
        }

        private void Stats_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(StatsAction));
        }

    }
}
