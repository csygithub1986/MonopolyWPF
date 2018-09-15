using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyWPF
{
    public class MainWindowVM : ModelBase
    {

        public GameLogic GameData { get { return _GameLogic; } set { if (_GameLogic != value) { _GameLogic = value; NotifyPropertyChanged(); } } }
        private GameLogic _GameLogic;


        public MainWindowVM()
        {
            GameData = GameLogic.Default;
        }
    }
}
