using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using Windows.ApplicationModel.Appointments.DataProvider;
using Windows.ApplicationModel.DataTransfer;
using TimHanewich.Csv;
using Mercury.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mercury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_MainMenu : Page
    {
        public Page_MainMenu()
        {
            this.InitializeComponent();

            //Set background color
            Rectangle_Background.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 240, 206));

            SetUpServices();
            LoadVersionNotes();
            
        }

        public async void LoadVersionNotes()
        {
            StorageFile myFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///ReleaseNotes.csv"));
            string content = await Windows.Storage.FileIO.ReadTextAsync(myFile);
            CsvFile file = CsvFile.CreateFromCsvFileContent(content);
            int t = 0;
            for (t=file.Rows.Count-1;t>0;t--)
            {
                string version = file.Rows[t].Values[0];
                string publish_date = file.Rows[t].Values[1];
                string notes = file.Rows[t].Values[2];
                string full = "v" + version + " (" + publish_date + ") " + notes;

                TextBlock tb = new TextBlock();
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.Text = full;
                tb.TextWrapping = TextWrapping.WrapWholeWords;
                tb.Margin = new Thickness(5);
                StackPanel_WhatsNew.Children.Add(tb);
                
            }
        }

        public async void SetUpServices()
        {
            //Live Market
            StorageFile img_livemarkets = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Graphics/LiveMarketBoard.jpg"));
            Stream s1 = await img_livemarkets.OpenStreamForReadAsync();
            UserControl_MercuryService ms = new UserControl_MercuryService("Live Markets", s1);
            ms.ApplyRecommendedDimensions();
            StackPanel_Services.Children.Add(ms);

            //Financials
            StorageFile img_financials = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Graphics/Financials2.jpg"));
            Stream s2 = await img_financials.OpenStreamForReadAsync();
            UserControl_MercuryService ms2 = new UserControl_MercuryService("Financials", s2);
            ms2.ApplyRecommendedDimensions();
            StackPanel_Services.Children.Add(ms2);

        }
        


    }
}
