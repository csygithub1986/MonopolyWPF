using CommonControl;
using MapEditor;
using Model;
using MonopolyWPF.View;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonopolyWPF
{
    public partial class MainWindow : Window
    {
        bool m_InteractEnable; //是否可以操作界面

        private Canvas m_MapCanvas;
        Point m_MapCanvasPosition;
        private IEnumerable<LocationControl> m_LocationControls;
        private Map m_Map;

        MainWindowVM VM;
        public MainWindow()
        {
            InitializeComponent();

            VM = new MainWindowVM();
            DataContext = VM;
        }


        private void BeforeMove()
        {
            switch (GameLogic.Default.CurrentPlayer.AbnormalState)
            {
                case AbnormalState.无:
                    break;
                case AbnormalState.进医院:
                    break;
                case AbnormalState.进监狱:
                    break;
                case AbnormalState.住酒店:
                    break;
                case AbnormalState.睡眠:
                    break;
                case AbnormalState.梦游:
                    break;
            }
        }


        private void Move(int step)
        {
        }

        private void AfterMove()
        {
            //TODO:结算、附神等操作


            GameLogic.Default.ChangeTurn();
        }

        #region 界面事件
        private void Buttoncard_Click(object sender, RoutedEventArgs e)
        {
            ChooseCardDialog g = new ChooseCardDialog();
            var re = g.ShowDialog();
            if (re == true)
            {
                GameLogic.Default.CurrentPlayer.UIInputStrategy();
            }
        }

        private void Buttonmove_Click(object sender, RoutedEventArgs e)
        {
            GameLogic.Default.CurrentPlayer.UIInputMove();
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("D:/Map1.txt", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                m_Map = (Map)formatter.Deserialize(fs);
            }
            if (m_Map != null)
            {
                m_MapCanvas = (Canvas)XamlReader.Parse(m_Map.MapGraph);
                mainCanvas.Children.Add(m_MapCanvas);
                m_MapCanvasPosition = new Point(0, 0);
            }

            Map.DeserializeMap(m_Map);

            GameLogic.Default.Init(m_Map);
            m_LocationControls = m_MapCanvas.Children.OfType<LocationControl>();
            BindingLocationControl();
            InitPlayerLocaton();

            GameLogic.Default.Start();

            GameLogic.Default.MoveEvent += Game_MoveEvent;
        }

        private void BindingLocationControl()
        {
            foreach (var ctrl in m_LocationControls)
            {
                ctrl.Location = m_Map.LocationCollection.First(p => p.Index == ctrl.LocationIndex);
            }
        }

        private void Game_MoveEvent(List<int> routeList)
        {
            m_RouteList = routeList;
            m_AnimationStep = 0;
            MoveAnimation();
        }
        int m_AnimationStep = 0;
        List<int> m_RouteList;

        private void MoveAnimation()
        {
            if (m_AnimationStep >= m_RouteList.Count - 1)
            {
                GameLogic.Default.MoveOver();
                return;
            }
            LocationControl locCtrl1 = m_LocationControls.First(p => p.LocationIndex == m_RouteList[m_AnimationStep]);
            LocationControl locCtrl2 = m_LocationControls.First(p => p.LocationIndex == m_RouteList[m_AnimationStep + 1]);
            m_AnimationStep++;

            DoubleAnimation da1 = new DoubleAnimation((double)locCtrl1.GetValue(Canvas.LeftProperty), (double)locCtrl2.GetValue(Canvas.LeftProperty), new Duration(new TimeSpan(0, 0, 0, 0, 300)));
            DoubleAnimation da2 = new DoubleAnimation((double)locCtrl1.GetValue(Canvas.TopProperty), (double)locCtrl2.GetValue(Canvas.TopProperty), new Duration(new TimeSpan(0, 0, 0, 0, 300)));

            Storyboard.SetTargetProperty(da1, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(da2, new PropertyPath(Canvas.TopProperty));

            Storyboard sb = new Storyboard();
            sb.Completed += Sb_Completed;
            sb.Children.Add(da1);
            sb.Children.Add(da2);
            sb.Begin(m_PlayerUIDic[GameLogic.Default.CurrentPlayer]);
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            MoveAnimation();
        }


        private Dictionary<Player, Label> m_PlayerUIDic;

        private void InitPlayerLocaton()
        {
            m_PlayerUIDic = new Dictionary<Player, Label>();
            foreach (var player in GameLogic.Default.Players)
            {
                Label label = new Label();
                label.Padding = new Thickness(3);
                label.FontSize = 24;
                label.Content = player.Role.Name;
                label.Background = player.Role.Color;

                Location loc = GameLogic.Default.Map.LocationCollection.First(p => p.Index == player.Location.Index);
                LocationControl locCtrl = m_LocationControls.First(p => p.Location == player.Location);
                label.SetValue(Canvas.LeftProperty, locCtrl.GetValue(Canvas.LeftProperty));
                label.SetValue(Canvas.TopProperty, locCtrl.GetValue(Canvas.TopProperty));
                m_MapCanvas.Children.Add(label);

                m_PlayerUIDic.Add(player, label);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestMapWindow w = new TestMapWindow();
            w.ShowDialog();
        }

        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            Map map = null;
            using (FileStream fs = new FileStream("D:/Map1.txt", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                map = (Map)formatter.Deserialize(fs);
            }
            if (map != null)
            {
                Canvas canvas = (Canvas)XamlReader.Parse(map.MapGraph);
                mainCanvas.Children.Add(canvas);
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region 鼠标动作
        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPos = e.GetPosition(mainCanvas);
                double x = m_MapCanvasPosition.X + (currentPos.X - m_MouseDownPosition.X);
                double y = m_MapCanvasPosition.Y + (currentPos.Y - m_MouseDownPosition.Y);
                //Console.WriteLine("X移动 " + (currentPos.X - m_MouseDownPosition.X) + " Y移动 " + (currentPos.Y - m_MouseDownPosition.Y));
                x = x > 0 ? 0 : x;
                x = x < mainCanvas.Width - m_MapCanvas.Width ? mainCanvas.Width - m_MapCanvas.Width : x;
                y = y > 0 ? 0 : y;
                y = y < mainCanvas.Height - m_MapCanvas.Height ? mainCanvas.Height - m_MapCanvas.Height : y;
                m_MapCanvasPosition = new Point(x, y);
                m_MapCanvas.SetValue(Canvas.LeftProperty, x);
                m_MapCanvas.SetValue(Canvas.TopProperty, y);
                m_MouseDownPosition = currentPos;
                //Console.WriteLine("当前位置 " + x + " , " + y);
            }
        }

        #endregion

        //private Point m_LastMouseMovePos;
        private Point m_MouseDownPosition;

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            m_MouseDownPosition = e.GetPosition(mainCanvas);
        }
    }
}
