using CefSharp;
using CefSharp.Wpf;
using CefSharp.Wpf.Experimental;
using CefSharp.Wpf.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowser.Core
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            if (!Common.IsInit)
                Common.Init();
            InitializeComponent();
            Browser.LifeSpanHandler = new CefLifeSpanHandler();
            Browser.WpfKeyboardHandler = new WpfKeyboardHandler(Browser);
            //Browser.WpfKeyboardHandler = new WpfImeKeyboardHandler(Browser);
        }
        public class CefLifeSpanHandler : CefSharp.ILifeSpanHandler
        {
            public CefLifeSpanHandler()
            {
            }
            public bool DoClose(IWebBrowser browserControl, CefSharp.IBrowser browser)
            {
                if (browser.IsDisposed || browser.IsPopup)
                {
                    return false;
                }
                return true;
            }
            public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
            {
            }
            public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
            {
            }
            public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
            {
                //newBrowser = null;
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.Load(targetUrl);

                newBrowser = null;
                return true;

                // new_tab_browser(targetUrl);
                // return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Browser.Back();
            txtAddress.Text = Browser.Address;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Browser.Forward();
            txtAddress.Text = Browser.Address;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Browser.Load(txtAddress.Text.Trim());
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Browser.Width = this.ActualWidth * 2;
            //Browser.Height = this.ActualHeight * 2;
        }

        private void CommandBindingGo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Browser.Load(txtAddress.Text);
        }

        private void Browser_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control) return;

            if (e.Delta > 0)
            {
                Browser.ZoomInCommand.Execute(null);
            }
            else if (e.Delta < 0)
            {
                Browser.ZoomOutCommand.Execute(null);
            }
            e.Handled = true;
        }

        private void CommandBindingResetZoom_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Browser.SetZoomLevel(0);
        }
    }
}
