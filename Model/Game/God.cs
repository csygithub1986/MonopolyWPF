using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class God:ModelBase
    {
        public GodType GodType { get { return _GodType; } set { if (_GodType != value) { _GodType = value; NotifyPropertyChanged(); } } }
        private GodType _GodType;

        public int DaysRemain { get { return _DaysRemain; } set { if (_DaysRemain != value) { _DaysRemain = value; NotifyPropertyChanged(); } } }
        private int _DaysRemain;

        public God()
        {
            DaysRemain = 7;
        }
    }
}
