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
using System.Windows.Shapes;

namespace MonopolyWPF.View
{
    /// <summary>
    /// ChooseCardDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseCardDialog : Window
    {
        public CardType? Card { get; set; }

        public ChooseCardDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Card = CardType.乌龟卡;
            DialogResult = true;
        }
    }
}
