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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Mercury.Controls
{
    public sealed partial class UserControl_MercuryService : UserControl
    {
        public UserControl_MercuryService(string service_name, Stream background_image_stream)
        {
            InitializeComponent();

            TextBlock_ServiceName.Text = service_name;
            BitmapImage bmi = new BitmapImage();
            bmi.SetSource(background_image_stream.AsRandomAccessStream());
            Image_Background.Source = bmi;

            //Handlers
            PointerEntered += MouseOver;
            PointerExited += MouseLeave;

        }

        public void ApplyRecommendedDimensions()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Height = 150;
        }

        public void MouseOver(object sender, RoutedEventArgs e)
        {
            Image_GrayOut.Visibility = Visibility.Collapsed;
        }

        public void MouseLeave(object sender, RoutedEventArgs e)
        {
            Image_GrayOut.Visibility = Visibility.Visible;
        }
    }
}
