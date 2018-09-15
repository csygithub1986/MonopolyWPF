using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 住宅所属区
    /// </summary>
    public class ResidentArea : ModelBase
    {
        /// <summary>
        /// 区域名字
        /// </summary>
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; NotifyPropertyChanged(); } } }
        private string _Name;

        /// <summary>
        /// 基础购买价格
        /// </summary>
        public int BaseSellPrice { get { return _BaseSellPrice; } set { if (_BaseSellPrice != value) { _BaseSellPrice = value; NotifyPropertyChanged(); } } }
        private int _BaseSellPrice;

        /// <summary>
        /// 基础租金价格
        /// </summary>
        public int BaseRentPrice { get { return _BaseRentPrice; } set { if (_BaseRentPrice != value) { _BaseRentPrice = value; NotifyPropertyChanged(); } } }
        private int _BaseRentPrice;

    }

}
