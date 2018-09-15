using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 房产
    /// </summary>
    public class PropertyBase : ModelBase
    {
        /// <summary>
        /// 所属玩家
        /// </summary>
        public Player PlayerBelongTo { get { return _PlayerBelongTo; } set { if (_PlayerBelongTo != value) { _PlayerBelongTo = value; NotifyPropertyChanged(); } } }
        private Player _PlayerBelongTo;

        /// <summary>
        /// 级别。0~5级，0级为空地
        /// </summary>
        public int Level { get { return _Level; } set { if (_Level != value) { _Level = value; NotifyPropertyChanged(); } } }
        private int _Level;

        /// <summary>
        /// 购买价格
        /// </summary>
        public int SellPrice { get { return _SellPrice; } set { if (_SellPrice != value) { _SellPrice = value; NotifyPropertyChanged(); } } }
        private int _SellPrice;

        /// <summary>
        /// 租金价格
        /// </summary>
        public int RentPrice { get { return _RentPrice; } set { if (_RentPrice != value) { _RentPrice = value; NotifyPropertyChanged(); } } }
        private int _RentPrice;

        /// <summary>
        /// 是否被查封
        /// </summary>
        public bool IsClosed { get { return _IsClosed; } set { if (_IsClosed != value) { _IsClosed = value; NotifyPropertyChanged(); } } }
        private bool _IsClosed;
    }

}
