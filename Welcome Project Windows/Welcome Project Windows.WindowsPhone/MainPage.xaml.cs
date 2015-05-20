using FHSDK81.Phone;
using System.Diagnostics;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        private const int X = 3;
        private const int Y = 2;

        partial void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            var CurrentViewState = ApplicationView.GetForCurrentView().Orientation;
            switch (CurrentViewState)
            {
                case ApplicationViewOrientation.Landscape:
                    PivotGrid(X, Y);

                    break;

                case ApplicationViewOrientation.Portrait:
                    PivotGrid(Y, X);

                    break;
            }
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
