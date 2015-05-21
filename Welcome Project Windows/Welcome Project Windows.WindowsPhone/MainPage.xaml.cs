using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;

namespace Welcome_Project_Windows
{
    public partial class MainPage : Page
    {
        private const int X = 3;
        private const int Y = 2;

        partial void OrientationChanged(DisplayInformation info, object sender)
        {
            switch (info.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                case DisplayOrientations.LandscapeFlipped:
                    PivotGrid(X, Y);

                    break;

                case DisplayOrientations.Portrait:
                case DisplayOrientations.PortraitFlipped:
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
