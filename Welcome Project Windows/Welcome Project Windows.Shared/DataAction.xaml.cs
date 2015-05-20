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
    public sealed partial class DataAction : Page
    {
        public DataAction()
        {
            this.InitializeComponent();
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameField.Text))
            {
                await new MessageDialog("Please enter a name", "Error").ShowAsync();
            }
            IDictionary<string, object> data = new Dictionary<string, object>();
            
            data["collection"] = "Users";
            data["document"] = new Dictionary<string, string>() {{ "username", NameField.Text}};

            FHResponse res = await FH.Cloud("saveData", "POST", null, data);
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await new MessageDialog("Server error", "Error").ShowAsync();
            }

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
