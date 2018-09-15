using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class TimeBomb : ModelBase
    {

        public int DaysRemain { get { return _DaysRemain; } set { if (_DaysRemain != value) { _DaysRemain = value; NotifyPropertyChanged(); } } }
        private int _DaysRemain;

    }

}
