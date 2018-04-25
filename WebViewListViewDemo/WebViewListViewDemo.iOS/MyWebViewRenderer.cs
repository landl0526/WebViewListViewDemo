using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using WebViewListViewDemo;
using WebViewListViewDemo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AutoWebView), typeof(MyWebViewRenderer))]
namespace WebViewListViewDemo.iOS
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            Delegate = new ExtendedUIWebViewDelegate(this);
        }
    }

    public class ExtendedUIWebViewDelegate : UIWebViewDelegate
    {
        MyWebViewRenderer webViewRenderer;

        public ExtendedUIWebViewDelegate(MyWebViewRenderer _webViewRenderer = null)
        {
            webViewRenderer = _webViewRenderer ?? new MyWebViewRenderer();
        }

        public override void LoadingFinished(UIWebView webView)
        {
            var wv = webViewRenderer.Element as AutoWebView;
            if (wv.HeightRequest < 0)
            {
                wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
                (wv.Parent.Parent as ViewCell).ForceUpdateSize();
            }
        }
    }
}