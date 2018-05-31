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

namespace CommonControl
{
    /// <summary>
    /// 住宅
    /// </summary>
    public partial class HouseControl : UserControl
    {
        public HouseControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 住宅类实体
        /// </summary>
        public House House { get { return (House)GetValue(HouseProperty); } set { SetValue(HouseProperty, value); } }
        public static readonly DependencyProperty HouseProperty = DependencyProperty.Register("House", typeof(House), typeof(HouseControl), new PropertyMetadata(null));


    }
}
