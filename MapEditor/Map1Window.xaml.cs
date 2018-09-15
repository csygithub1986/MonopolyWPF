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
    public partial class Map1Window : Window
    {
        public Map1Window()
        {
            InitializeComponent();
            //abc.CommercialAsset = new Model.CommercialAsset();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<CommercialAssetControl> commercialList = new List<CommercialAssetControl>();
            //List<LocationControl> locationList = new List<LocationControl>();
            //List<ResidenceControl> residentControlList = new List<ResidenceControl>();
            //foreach (var item in grid.Children)
            //{
            //    Control con = item as Control;
            //    if (con == null)
            //    {
            //        continue;
            //    }
            //    double left = con.Margin.Left;
            //    double top = con.Margin.Top;
            //    Canvas.SetLeft(con, left);
            //    Canvas.SetTop(con, top);
            //    con.Margin = new Thickness();
            //    if (item is LocationControl)
            //    {
            //        if (locationList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
            //        {
            //            var locItem = item as LocationControl;
            //            LocationControl c = new LocationControl();
            //            c.LocationIndex = locItem.LocationIndex;
            //            c.ControlDirection = locItem.ControlDirection;
            //            Canvas.SetLeft(c, left);
            //            Canvas.SetTop(c, top);
            //            locationList.Add(c);
            //        }
            //        else Console.WriteLine("重复的LocationControl");
            //    }
            //    else if (item is CommercialAssetControl)
            //    {
            //        if (commercialList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
            //        {
            //            CommercialAssetControl c = new CommercialAssetControl();
            //            Canvas.SetLeft(c, left);
            //            Canvas.SetTop(c, top);
            //            commercialList.Add(c);
            //        }
            //        else Console.WriteLine("重复的CommercialAssetControl");
            //    }
            //    else if (item is ResidenceControl)
            //    {
            //        if (residentControlList.FirstOrDefault(p => (double)p.GetValue(Canvas.LeftProperty) == left && (double)p.GetValue(Canvas.LeftProperty) == top) == null)
            //        {
            //            ResidenceControl c = new ResidenceControl();
            //            Canvas.SetLeft(c, left);
            //            Canvas.SetTop(c, top);
            //            residentControlList.Add(c);
            //        }
            //        else Console.WriteLine("重复的ResidentControl");
            //    }
            //}

            //Canvas canvas = new Canvas();
            //canvas.Width = grid.Width;
            //canvas.Height = grid.Height;
            //canvas.Background = grid.Background;
            //scroll.Content = canvas;

            //locationList.Sort(new Comparison<LocationControl>((x, y) =>
            //{
            //    if (x.LocationIndex > y.LocationIndex) return 1;
            //    if (x.LocationIndex < y.LocationIndex) return -1;
            //    return 0;
            //}));
            //foreach (var item in locationList)
            //{
            //    canvas.Children.Add(item);
            //}
            //foreach (var item in commercialList)
            //{
            //    canvas.Children.Add(item);
            //}
            //foreach (var item in residentControlList)
            //{
            //    canvas.Children.Add(item);
            //}
            //Map map = new Map();
            //map.MapGraph = XamlWriter.Save(canvas);
            //map.LocationCollection = new System.Collections.ObjectModel.Collection<Location>();

            //using (FileStream fs = new FileStream("D:/Map1.txt", FileMode.Create))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, map);
            //}
        }

        private void MenuExportMap_Click(object sender, RoutedEventArgs e)
        {

            Map map = new Map();
            map.MapGraph = XamlWriter.Save(mainCanvas);
            map.LocationCollection = new System.Collections.ObjectModel.Collection<Location>();
            var locationControls = mainCanvas.Children.OfType<LocationControl>();
            foreach (var item in locationControls)
            {
                Location loc = new Location()
                {
                    Index = item.LocationIndex,
                    LocationType = LocationType.住宅地产,
                };
                map.LocationCollection.Add(loc);
            }
            foreach (var loc in map.LocationCollection)
            {
                int backwardIndex = loc.Index <= 1 ? map.LocationCollection.Count : loc.Index - 1;
                int forwardIndex = loc.Index >= map.LocationCollection.Count ? 1 : loc.Index + 1;

                loc.RoadInfos.Add(new RoadInfo()
                {
                    RoadIndex = 1,
                    BackwardLocation = map.LocationCollection.First(p => p.Index == backwardIndex),
                    ForwardLocation = map.LocationCollection.First(p => p.Index == forwardIndex)
                });
            }

            using (FileStream fs = new FileStream("D:/Map1.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, map);
            }
            MessageBox.Show("OK");
        }
    }
}
