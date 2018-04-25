using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using WebViewListViewDemo;
using WebViewListViewDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AutoWebView), typeof(MyWebViewAndroidRenderer))]
namespace WebViewListViewDemo.Droid
{
    public class MyWebViewAndroidRenderer : WebViewRenderer
    {
        public MyWebViewAndroidRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
            Control.SetWebViewClient(new ExtendedWebViewClient(Element as AutoWebView));
           
        }

        class ExtendedWebViewClient : Android.Webkit.WebViewClient
        {
            AutoWebView xwebView;
            public ExtendedWebViewClient(AutoWebView webView)
            {
                xwebView = webView;
            }

            async public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                if (xwebView != null)
                {
                    int i = 10;
                    while (view.ContentHeight == 0 && i-- > 0) // wait here till content is rendered
                        await System.Threading.Tasks.Task.Delay(100);
                    xwebView.HeightRequest = view.ContentHeight;
                    (xwebView.Parent.Parent as ViewCell).ForceUpdateSize();
                }
               
                base.OnPageFinished(view, url);
            }
        }
    }
}