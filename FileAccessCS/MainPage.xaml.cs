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

namespace FileAccessCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            webView.NavigationCompleted += WebView_NavigationCompleted;

            FileAccessPolyFill.WindowsRT w = new FileAccessPolyFill.WindowsRT();

            webView.AddWebAllowedObject("WindowsPolyFill", w);

            //webView.AddWebAllowedObject("Windows.Storage.KnownFolderId", new WindowsPolyFill.Storage.KnownFolderId());
            webView.Navigate(new Uri("ms-appx-web:///default.html"));
        }

        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            bool success = args.IsSuccess;
        }
    }
}
