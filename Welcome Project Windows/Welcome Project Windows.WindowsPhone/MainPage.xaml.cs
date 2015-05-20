using FHSDK81.Phone;
using System.Diagnostics;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

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

            this.NavigationCacheMode = NavigationCacheMode.Required;
            Current_SizeChanged(null, null);
        }

        private async void InitApp()
        {
            await FHClient.Init();
        }

        private const int X = 3;
        private const int Y = 2;

        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Get the new view state
            // Add: using Windows.UI.ViewManagement;
            var CurrentViewState = ApplicationView.GetForCurrentView().Orientation;
            switch (CurrentViewState)
            {
                case ApplicationViewOrientation.Landscape:
                    PivotGrid(X, Y);
                    buttons.Margin = new Thickness(30);
                    logo.Margin = new Thickness(5);

                    break;

                case ApplicationViewOrientation.Portrait:
                    PivotGrid(Y, X);
                    buttons.Margin = new Thickness(15);
                    logo.Margin = new Thickness(15);

                    break;
            }
        }

        private void Cloud_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(CloudAction));
        }

        private void Data_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DataAction));
        }

        private void PivotGrid(int x, int y)
        {
            buttons.RowDefinitions.Clear();
            buttons.ColumnDefinitions.Clear();
            int count = 0;
            for (int j = 0; j < y; j++)
            {
                buttons.RowDefinitions.Add(new RowDefinition());

                for (int i = 0; i < x; i++)
                {
                    if (j == 0)
                    {
                        buttons.ColumnDefinitions.Add(new ColumnDefinition());
                    }

                    var grid = buttons.Children[count++];
                    grid.SetValue(Grid.ColumnProperty, i);
                    grid.SetValue(Grid.RowProperty, j);
                }
            }
        }
    }
}
