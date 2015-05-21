using FHSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Welcome_Project_Windows
{
    public sealed partial class StatsAction : Page
    {
        public StatsAction()
        {
            this.InitializeComponent();
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
