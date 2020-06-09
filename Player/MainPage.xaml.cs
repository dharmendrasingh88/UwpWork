using PocsLibs.Helpers;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Player
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// I am using Iframe of google to play video for more info use this thanks for google 
    ///  https://developers.google.com/youtube/iframe_api_reference#Loading_a_Video_Player
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Please note GetVideo Id and Add parameter added by us to Uri Extenstion
            //https://www.youtube.com/watch?v=M7lc1UVf-VE
            string videoId = new Uri(!string.IsNullOrEmpty(txtYoutubeUrl.ToString())?txtYoutubeUrl.ToString(): "https://www.youtube.com/watch?v=M7lc1UVf-VE").GetVideoId();

            //in my case i need must /// after ms-appx-web so passing as 
            WebViewPlayer.Source = new Uri("ms-appx-web://///Html/Player.html").AddParameter("videoId", videoId);

        }
    }
}
