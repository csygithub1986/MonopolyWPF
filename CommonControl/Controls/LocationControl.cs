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
    public class LocationControl : ContentControl
    {
        static LocationControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LocationControl), new FrameworkPropertyMetadata(typeof(LocationControl)));
        }

        /// <summary>
        /// 是否显示设计时的辅助控件
        /// </summary>
        public Visibility DesignVisibility { get { return (Visibility)GetValue(DesignVisibilityProperty); } set { SetValue(DesignVisibilityProperty, value); } }
        public static readonly DependencyProperty DesignVisibilityProperty = DependencyProperty.Register("DesignVisibility", typeof(Visibility), typeof(LocationControl), new PropertyMetadata(Visibility.Collapsed));


        /// <summary>
        /// 绑定的位置数据（只在程序运行时计算出该字段，序列化时不要记录该字段）
        /// </summary>
        public Location Location
        {
            get { return (Location)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
        public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(Location), typeof(LocationControl), new PropertyMetadata(null));

        /// <summary>
        /// 位置的索引（序列化时用）从1开始
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(1)]
        [System.ComponentModel.Description("位置的索引")]
        [System.ComponentModel.Category("自定义")]
        public int LocationIndex
        {
            get { return (int)GetValue(LocationIndexProperty); }
            set { SetValue(LocationIndexProperty, value); }
        }
        public static readonly DependencyProperty LocationIndexProperty = DependencyProperty.Register("LocationIndex", typeof(int), typeof(LocationControl), new PropertyMetadata(0));

        ///// <summary>
        ///// 控件的方向。为True时，方向往左上方，为False时，往右上方
        ///// </summary>
        //[System.ComponentModel.Browsable(true)]
        //[System.ComponentModel.DefaultValue(false)]
        //[System.ComponentModel.Description("控件的方向是否反向")]
        //[System.ComponentModel.Category("自定义")]
        //public bool IsDireReverse { get { return (bool)GetValue(IsDireReverseProperty); } set { SetValue(IsDireReverseProperty, value); } }
        //public static readonly DependencyProperty IsDireReverseProperty = DependencyProperty.Register("IsDireReverse", typeof(bool), typeof(LocationControl), new PropertyMetadata(false));

        /// <summary>
        /// 控件的方向类型
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(LocControlDirection.LeftUp)]
        [System.ComponentModel.Description("控件的方向类型")]
        [System.ComponentModel.Category("自定义")]
        public LocControlDirection ControlDirection { get { return (LocControlDirection)GetValue(ControlDirectionProperty); } set { SetValue(ControlDirectionProperty, value); } }
        public static readonly DependencyProperty ControlDirectionProperty = DependencyProperty.Register("ControlDirection", typeof(LocControlDirection), typeof(LocationControl), new PropertyMetadata(LocControlDirection.LeftUp));

    }
}
