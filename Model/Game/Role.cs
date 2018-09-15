using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    /// <summary>
    /// 动画人物
    /// </summary>
    public class Role : ModelBase
    {
        public int ID { get { return _ID; } set { if (_ID != value) { _ID = value; NotifyPropertyChanged(); } } }
        private int _ID;


        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; NotifyPropertyChanged(); } } }
        private string _Name;


        public object ImageSource { get { return _ImageSource; } set { if (_ImageSource != value) { _ImageSource = value; NotifyPropertyChanged(); } } }
        private object _ImageSource;


        public Brush Color { get { return _Color; } set { if (_Color != value) { _Color = value; NotifyPropertyChanged(); } } }
        private Brush _Color;


    }
}
