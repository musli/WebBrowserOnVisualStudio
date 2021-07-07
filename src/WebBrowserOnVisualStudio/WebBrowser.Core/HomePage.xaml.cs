using CefSharp;
using CefSharp.Wpf;
using CefSharp.Wpf.Experimental;
using CefSharp.Wpf.Internals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win32;
using static Win32.User;

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
            Browser.LifeSpanHandler = new CefLifeSpanHandler(Browser);
            Browser.MenuHandler = new MenuHandler();
            //Browser.RequestHandler = new RequestHandler();
            Browser.WpfKeyboardHandler = new WpfKeyboardHandler(Browser);
            //Browser.WpfKeyboardHandler = new WpfImeKeyboardHandler(Browser);
        }
        /// <summary>
        /// 页面生命周期
        /// </summary>
        public class CefLifeSpanHandler : CefSharp.ILifeSpanHandler
        {
            ChromiumWebBrowser chromium;
            public CefLifeSpanHandler(ChromiumWebBrowser owner)
            {
                chromium = owner;
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
                newBrowser = null;
                return false;
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.Load(targetUrl);
                newBrowser = null;
                return true;
            }
        }
        /// <summary>
        /// 右键菜单
        /// </summary>
        public class MenuHandler : IContextMenuHandler
        {
            public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
            {
            }
            public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
            {
                return false;
            }
            public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
            {
            }
            public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
            {
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.Dispatcher.Invoke(() =>
                {
                    //显示菜单
                    chromiumWebBrowser.ContextMenu.IsOpen = true;

                });

                return true;
            }
        }
        public class RequestHandler : IRequestHandler
        {

            public RequestHandler()
            {
            }

            public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });

                return false;
            }

            public IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                if (request.Method.ToUpper() == "POST" && request.PostData != null)
                {
                    if (request.PostData.Elements.Count > 0)
                    {
                        //_browser.PostData = new byte[request.PostData.Elements[0].Bytes.Length];
                        //request.PostData.Elements[0].Bytes.CopyTo(_browser.PostData, 0);
                    }
                }
                return null;
            }

            public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                return false;
            }

            public bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                return false;
            }

            public bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                return false;
            }

            public void OnPluginCrashed(IWebBrowser chromiumWebBrowser, IBrowser browser, string pluginPath)
            {

                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
            }

            public bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                return false;
            }

            public void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
            {

                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
            }

            public void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
            {

                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
            }

            public bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
            {
                var tempBro = (ChromiumWebBrowser)chromiumWebBrowser;
                tempBro.Dispatcher.Invoke(() =>
                {
                    var d = tempBro.Address;
                });
                return false;
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

        /// <summary>
        /// 打开开发者工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Browser.ShowDevTools();
        }

        IntPtr intPtr1 = IntPtr.Zero;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            var browserHandle = (IntPtr)User.FindWindow("CefBrowserWindow", null);

            //消除边框
            var style = User.GetWindowLong(browserHandle, User.GWL_STYLE);
            style &= ~(int)(User.WS_EX_TOOLWINDOW | User.WS_CAPTION | User.WS_THICKFRAME |
                User.WS_MINIMIZEBOX | User.WS_MAXIMIZEBOX | User.WS_MAXIMIZE | User.WS_SYSMENU);
            User.SetWindowLong(browserHandle, User.GWL_STYLE, style);

            //设置透明
            int exStyle = User.GetWindowLong(browserHandle, User.GWL_EXSTYLE);
            exStyle |= (int)User.WS_EX_LAYERED;
            User.SetWindowLong(browserHandle, User.GWL_EXSTYLE, exStyle);

            Task.Run(() =>
            {
                Thread.Sleep(100);
                Dispatcher.Invoke(() =>
                {
                    var app = new EmbeddedApp(browserHandle);
                    grid.Children.Add(app);
                });
                User.SetLayeredWindowAttributes(browserHandle, 0xffffff, 20, 2);
            });
           
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
        }
    }
    public class EmbeddedApp : HwndHost, IKeyboardInputSink
    {
        private IntPtr TargetHWND;

        public EmbeddedApp(IntPtr intPtr)
        {
            TargetHWND = intPtr;
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {

            //改变样式
            //User.ShowWindow(TargetHWND, User.SW_SHOW);
            //User.EnableWindow(TargetHWND, 1);
            int style = User.GetWindowLong(TargetHWND, User.GWL_STYLE);
            //style = style & ~((int)User.WS_CAPTION) & ~((int)User.WS_THICKFRAME);
            style |= ((int)User.WS_CHILD);
            style |= ((int)User.WS_CLIPCHILDREN);
            User.SetWindowLong(TargetHWND, User.GWL_STYLE, User.WS_CHILD);

            //嵌入进去
            User.SetParent(TargetHWND, hwndParent.Handle);
            return new HandleRef(this, TargetHWND);



        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            Console.WriteLine("释放了");
        }
    }
}
