using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 位置
    /// </summary>
    [Serializable]
    public class Location : ModelBase
    {
        public int Index { get { return _Index; } set { if (_Index != value) { _Index = value; NotifyPropertyChanged(); } } }
        private int _Index;

        public LocationType LocationType { get { return _LocationType; } set { if (_LocationType != value) { _LocationType = value; NotifyPropertyChanged(); } } }
        private LocationType _LocationType;

        public object Content { get { return _Content; } set { if (_Content != value) { _Content = value; NotifyPropertyChanged(); } } }
        private object _Content;

        public Collection<RoadInfo> RoadInfos { get { return _RoadInfos; } set { if (_RoadInfos != value) { _RoadInfos = value; NotifyPropertyChanged(); } } }
        private Collection<RoadInfo> _RoadInfos = new Collection<RoadInfo>();
    }


}
