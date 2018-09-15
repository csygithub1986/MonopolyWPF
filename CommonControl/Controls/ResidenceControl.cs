using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommonControl
{
    public class ResidenceControl : ContentControl
    {
        static ResidenceControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResidenceControl), new FrameworkPropertyMetadata(typeof(ResidenceControl)));
        }

        /// <summary>
        /// 后台数据
        /// </summary>
        public Residence Residence { get { return (Residence)GetValue(ResidenceProperty); } set { SetValue(ResidenceProperty, value); } }
        public static readonly DependencyProperty ResidenceProperty = DependencyProperty.Register("Residence", typeof(Residence), typeof(ResidenceControl), new PropertyMetadata(null));

    }
}
