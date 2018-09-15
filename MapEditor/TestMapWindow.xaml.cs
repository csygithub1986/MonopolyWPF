using CommonControl;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace MapEditor
{
    /// <summary>
    /// TestMapWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestMapWindow : Window
    {
        public TestMapWindow()
        {
            InitializeComponent();

            //主路数据
            int mainLocCount = 60;
            Collection<Location> collectionMain = new Collection<Location>();
            for (int i = 0; i < mainLocCount; i++)
            {
                collectionMain.Add(new Location() { Index = i });
            }
            for (int i = 0; i < mainLocCount; i++)
            {
                int forwardIndex = i + 1 > mainLocCount - 1 ? 0 : i + 1;
                int backwardIndex = i - 1 < 0 ? mainLocCount - 1 : i - 1;
                Location forward = collectionMain.First(p => p.Index == forwardIndex);
                Location backward = collectionMain.First(p => p.Index == backwardIndex);
                collectionMain.First(p => p.Index == i).RoadInfos.Add(new RoadInfo()
                {
                    RoadIndex = 0,
                    ForwardLocation = forward,
                    BackwardLocation = backward
                });
            }
            LocationCollection = collectionMain;
            //主路图形绑定
            for (int i = 0; i < mainLocCount; i++)
            {
                LocationControl locCtrl = new LocationControl();
                Binding binding = new Binding("Index");
                binding.Source = LocationCollection[i];
                locCtrl.SetBinding(LocationControl.LocationIndexProperty, binding);
                if (i < 20)
                {
                    locCtrl.SetValue(Canvas.LeftProperty, 200.0 + i * 100.0);
                    locCtrl.SetValue(Canvas.TopProperty, 200.0);
                }
                else if (i < 30)
                {
                    locCtrl.SetValue(Canvas.LeftProperty, 2100.0);
                    locCtrl.SetValue(Canvas.TopProperty, 300.0 + (i - 20) * 100.0);
                }
                else if (i < 50)
                {
                    locCtrl.SetValue(Canvas.LeftProperty, 2100.0 - (i - 30) * 100.0);
                    locCtrl.SetValue(Canvas.TopProperty, 1300.0);
                }
                else
                {
                    locCtrl.SetValue(Canvas.LeftProperty, 200.0);
                    locCtrl.SetValue(Canvas.TopProperty, 1200.0 - (i - 50) * 100.0);
                }
                canvas.Children.Add(locCtrl);
            }

            //支路数据
            int subLocCount = 10;
            Collection<Location> collectionSub = new Collection<Location>();
            for (int i = mainLocCount; i < mainLocCount + subLocCount; i++)
            {
                collectionSub.Add(new Location() { Index = i });
            }
            foreach (var item in collectionSub)
            {
                LocationCollection.Add(item);
            }
            for (int i = mainLocCount; i < mainLocCount + subLocCount; i++)
            {
                int forwardIndex = i + 1 > mainLocCount + subLocCount - 1 ? 39 : i + 1;//三岔口39
                int backwardIndex = i - 1 < mainLocCount ? 10 : i - 1;//三岔口10
                Location forward = LocationCollection.First(p => p.Index == forwardIndex);
                Location backward = LocationCollection.First(p => p.Index == backwardIndex);
                collectionSub.First(p => p.Index == i).RoadInfos.Add(new RoadInfo()
                {
                    RoadIndex = 1,//支线
                    ForwardLocation = forward,
                    BackwardLocation = backward
                });
            }
            //三岔路特殊处理
            LocationCollection[10].RoadInfos.Add(new RoadInfo()
            {
                RoadIndex = 1,//支线
                ForwardLocation = collectionSub[0],
                BackwardLocation = null
            });
            LocationCollection[39].RoadInfos.Add(new RoadInfo()
            {
                RoadIndex = 1,//支线
                ForwardLocation = null,
                BackwardLocation = collectionSub[subLocCount - 1]
            });

            //支路图形绑定
            for (int i = 0; i < subLocCount; i++)
            {
                LocationControl locCtrl = new LocationControl();
                Binding binding = new Binding("Index");
                binding.Source = collectionSub[i];
                locCtrl.SetBinding(LocationControl.LocationIndexProperty, binding);
                locCtrl.SetValue(Canvas.LeftProperty, 1200.0);
                locCtrl.SetValue(Canvas.TopProperty, 300.0 + i * 100.0);
                canvas.Children.Add(locCtrl);
            }
        }


        public Collection<Location> LocationCollection
        {
            get { return (Collection<Location>)GetValue(LocationCollectionProperty); }
            set { SetValue(LocationCollectionProperty, value); }
        }
        public static readonly DependencyProperty LocationCollectionProperty = DependencyProperty.Register("LocationCollection", typeof(Collection<Location>), typeof(TestMapWindow), new PropertyMetadata(null));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            map.MapGraph = XamlWriter.Save(canvas);
            map.LocationCollection = LocationCollection;

            using (FileStream fs = new FileStream("D:/abc.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, map);
            }
        }
    }
}
