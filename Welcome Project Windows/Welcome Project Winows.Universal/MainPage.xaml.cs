using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        partial void OrientationChanged(DisplayInformation info, object sender)
        {
            switch (info.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                case DisplayOrientations.LandscapeFlipped:
                    grid.RowDefinitions.Clear();
                    grid.ColumnDefinitions.Clear();
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    buttons.Margin = new Thickness(30);

                    break;

                case DisplayOrientations.Portrait:
                case DisplayOrientations.PortraitFlipped:
                    grid.RowDefinitions.Clear();
                    grid.ColumnDefinitions.Clear();
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
                    buttons.Margin = new Thickness(60);

                    break;
            }
        }
    }
}
