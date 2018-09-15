using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommonControl
{
    public class CommercialAssetControl : ContentControl
    {
        static CommercialAssetControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommercialAssetControl), new FrameworkPropertyMetadata(typeof(CommercialAssetControl)));
        }

        //[field: NonSerialized]
        public event Action SelectedEvent;

        /// <summary>
        /// 内部数据属性
        /// </summary>
        public CommercialAsset CommercialAsset { get { return (CommercialAsset)GetValue(CommercialAssetProperty); } set { SetValue(CommercialAssetProperty, value); } }
        public static readonly DependencyProperty CommercialAssetProperty = DependencyProperty.Register("CommercialAsset", typeof(CommercialAsset), typeof(CommercialAssetControl), new PropertyMetadata(null));

        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool IsSelected { get { return (bool)GetValue(IsSelectedProperty); } set { SetValue(IsSelectedProperty, value); } }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(CommercialAssetControl), new PropertyMetadata(false));

        /// <summary>
        /// 是否可选
        /// </summary>
        public bool Selectable { get { return (bool)GetValue(SelectableProperty); } set { SetValue(SelectableProperty, value); } }
        public static readonly DependencyProperty SelectableProperty = DependencyProperty.Register("Selectable", typeof(bool), typeof(CommercialAssetControl), new PropertyMetadata(false));

        //public void LandBorder_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        public CommandBase MouseDownCommand { get; set; }

        public CommercialAssetControl()
        {
        }

        public void InitCommand()
        {
            MouseDownCommand = new CommandBase(LandBorder_MouseDown, null);
        }

        private void LandBorder_MouseDown(object obj)
        {
            //最开始用点击UserControl，再VisualTreeHelper.HitTest命中测试的方法，border不能命中，可能是layout变换了的缘故
            //最后将上层的Image的IsHitTestVisible设为false，border即可被点中。
            IsSelected = true;
            SelectedEvent?.Invoke();
            Console.WriteLine("AAAAAAAAAAA");
            //e.Handled = true;
        }

        ///// <summary>
        ///// 图片资源
        ///// </summary>
        //public ImageSource ImageSource { get { return (ImageSource)GetValue(ImageSourceProperty); } set { SetValue(ImageSourceProperty, value); } }
        //public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CommercialAssetControl), new PropertyMetadata(null));

        //protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    base.OnPropertyChanged(e);
        //    if (e.Property == CommercialAssetProperty)
        //    {
        //        var asset = e.OldValue as CommercialAsset;
        //        if (asset != null)
        //        {
        //            asset.PropertyChanged -= CommercialAsset_PropertyChanged;
        //        }
        //        if (CommercialAsset != null)
        //        {
        //            CommercialAsset.PropertyChanged += CommercialAsset_PropertyChanged;
        //        }
        //    }
        //}

        //private void CommercialAsset_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName==)
        //    {

        //    }
        //}
    }
}
