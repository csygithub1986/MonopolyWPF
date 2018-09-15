using CommonControl;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapEditor
{
    /// <summary>
    /// Map1Window.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            //abc.CommercialAsset = new Model.CommercialAsset();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<CommercialAssetControl> commercialList = new List<CommercialAssetControl>();
            List<LocationControl> locationList = new List<LocationControl>();
            List<ResidentControl> residentControlList = new List<ResidentControl>();

            foreach (var item in grid.Children)
            {
                UserControl con = item as UserControl;
                if (con == null)
                {
                    continue;
                }
                double left = con.Margin.Left;
                double top = con.Margin.Top;
                Canvas.SetLeft(con, left);
                Canvas.SetTop(con, top);
                con.Margin = new Thickness();
                if (item is LocationControl)
                {
                    if (locationList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
                    {
                        locationList.Add(item as LocationControl);
                    }
                    else Console.WriteLine("重复的LocationControl");
                }
                else if (item is CommercialAssetControl)
                {
                    if (commercialList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
                    {
                        commercialList.Add(item as CommercialAssetControl);
                    }
                    else Console.WriteLine("重复的CommercialAssetControl");
                }
                else if (item is ResidentControl)
                {
                    if (residentControlList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
                    {
                        residentControlList.Add(item as ResidentControl);
                    }
                    else Console.WriteLine("重复的ResidentControl");
                }
            }
            grid.Children.Clear();

            Canvas canvas = new Canvas();
            this.Content = canvas;

            locationList.Sort(new Comparison<LocationControl>((x, y) =>
            {
                if (x.LocationIndex > y.LocationIndex) return 1;
                if (x.LocationIndex < y.LocationIndex) return -1;
                return 0;
            }));
            foreach (var item in locationList)
            {
                canvas.Children.Add(item);
            }
            foreach (var item in commercialList)
            {
                canvas.Children.Add(item);
            }
            foreach (var item in residentControlList)
            {
                canvas.Children.Add(item);
            }
            Map map = new Map();
            map.MapGraph = XamlWriter.Save(canvas);
            map.LocationCollection = new System.Collections.ObjectModel.Collection<Location>();

            using (FileStream fs = new FileStream("D:/Map1.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, map);
            }
        }

    }
}
