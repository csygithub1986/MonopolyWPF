using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Car: ModelBase
    {
        public CarType CarType { get { return _CarType; } set { if (_CarType != value) { _CarType = value; NotifyPropertyChanged(); } } }
        private CarType _CarType;



        public int DaysRemain { get { return _DaysRemain; } set { if (_DaysRemain != value) { _DaysRemain = value; NotifyPropertyChanged(); } } }
        private int _DaysRemain;

    }

}
