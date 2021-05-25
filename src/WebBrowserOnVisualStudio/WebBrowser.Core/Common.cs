using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Core
{
    public class Common
    {
        public static bool IsInit = false;

        public static void Init()
        {
            IsInit = true;
            CefSettings _settings = new CefSettings();
            //_settings.UserAgent = "tv.danmaku.bili/6250300 (Linux; U; Android 11; zh_CN; V1824A; Build/RP1A.200720.012; Cronet/81.0.4044.156)";
            Cef.Initialize(_settings);
        }
    }
}
