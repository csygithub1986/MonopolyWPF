using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommercialAsset : PropertyBase
    {
        /// <summary>
        /// 商业建筑类型。如果为空地，此属性无效
        /// </summary>
        public CommercialBuildingType BuildingType { get { return _BuildingType; } set { if (_BuildingType != value) { _BuildingType = value; NotifyPropertyChanged(); } } }
        private CommercialBuildingType _BuildingType;

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
