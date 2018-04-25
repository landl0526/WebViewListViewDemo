using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebViewListViewDemo
{
	public partial class MainPage : ContentPage
	{

        const string webStr = "<html>< head >< meta charset='utf-8'><title>html Simple Sample</title></head><body><h1>First Title</h1><p>First Paragraph</p></body></html>";
        List<string> list;
        public MainPage()
		{
			InitializeComponent();

            list = new List<string>();

            for (int i=0; i<5; i++)
            {
                list.Add(webStr);
            }
            MyListView.ItemsSource = list;
        }
	}
}
