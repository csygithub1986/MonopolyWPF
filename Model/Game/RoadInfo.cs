using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class RoadInfo : ModelBase
    {
        public int RoadIndex { get { return _RoadIndex; } set { if (_RoadIndex != value) { _RoadIndex = value; NotifyPropertyChanged(); } } }
        private int _RoadIndex;

        public Location ForwardLocation { get { return _ForwardLocation; } set { if (_ForwardLocation != value) { _ForwardLocation = value; ForwardLocationIndex = value.Index; NotifyPropertyChanged(); } } }
        [NonSerialized]
        private Location _ForwardLocation;

        public Location BackwardLocation { get { return _BackwardLocation; } set { if (_BackwardLocation != value) { _BackwardLocation = value; BackwardLocationIndex = value.Index; NotifyPropertyChanged(); } } }
        [NonSerialized]
        private Location _BackwardLocation;

        public int ForwardLocationIndex { get { return _ForwardLocationIndex; } private set { if (_ForwardLocationIndex != value) { _ForwardLocationIndex = value; NotifyPropertyChanged(); } } }
        private int _ForwardLocationIndex = -1;

        public int BackwardLocationIndex { get { return _BackwardLocationIndex; } private set { if (_BackwardLocationIndex != value) { _BackwardLocationIndex = value; NotifyPropertyChanged(); } } }
        private int _BackwardLocationIndex = -1;
    }
}
