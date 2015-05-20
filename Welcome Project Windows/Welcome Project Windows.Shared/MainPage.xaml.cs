using FHSDK81.Phone;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            Window.Current.SizeChanged += Current_SizeChanged;
            this.InitializeComponent();
            this.InitApp();
            Current_SizeChanged(null, null);
        }

        private async void InitApp()
        {
            await FHClient.Init();
        }

        partial void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e);

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
    }
}
