using Model;
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

namespace MonopolyWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var house = new House()
            {
                Level = 1,
                PlayerBelongTo = new Player() { Role = new Role() { Name = "SSM" }, Color = Brushes.Red },
                Prices = new int[] { 10, 20, 300, 40, 50, 60 },
                RentPrices = new int[] { 100, 200, 300, 400, 500, 600 }
            };
            house1.House = house;
        }
    }
}
