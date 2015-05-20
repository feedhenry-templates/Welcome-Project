using FHSDK;
using FHSDK81.Phone;
using System.Diagnostics;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        partial void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
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
    }
}
