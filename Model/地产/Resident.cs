using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 住宅
    /// </summary>
    public class Residence : PropertyBase
    {
        /// <summary>
        /// 所属区域
        /// </summary>
        public ResidentArea AreaBelongTO { get { return _AreaBelongTO; } set { if (_AreaBelongTO != value) { _AreaBelongTO = value; NotifyPropertyChanged(); } } }
        private ResidentArea _AreaBelongTO;


    }

}
