using FHSDK;
using FHSDK81.Phone;
using System.Diagnostics;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Welcome_Project_Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
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

        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Get the new view state
            // Add: using Windows.UI.ViewManagement;
            var CurrentViewState = ApplicationView.GetForCurrentView().Orientation;
            switch (CurrentViewState)
            {
                case ApplicationViewOrientation.Landscape:
                    grid.RowDefinitions.Clear();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    buttons.Margin = new Thickness(30);

                    break;

                case ApplicationViewOrientation.Portrait:
                    grid.ColumnDefinitions.Clear();
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
                    buttons.Margin = new Thickness(60);

                    break;
            }
        }

        private void Cloud_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Cloud action clicked!");
            Frame.Navigate(typeof(CloudAction));
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Data browser clicked!");
        }
    }
}
