using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class Player : ModelBase, IPlayer
    {
        public int ID { get { return _ID; } set { if (_ID != value) { _ID = value; NotifyPropertyChanged(); } } }
        private int _ID;

        public Role Role { get { return _Role; } set { if (_Role != value) { _Role = value; NotifyPropertyChanged(); } } }
        private Role _Role;

        public Location Location { get { return _Location; } set { if (_Location != value) { _Location = value; NotifyPropertyChanged(); } } }
        private Location _Location;

        public int RoadIndex { get { return _RoadIndex; } set { if (_RoadIndex != value) { _RoadIndex = value; NotifyPropertyChanged(); } } }
        private int _RoadIndex;

        /// <summary>
        /// 行进方向，1和-1
        /// </summary>
        public int Direction { get { return _Direction; } set { if (_Direction != value) { _Direction = value; NotifyPropertyChanged(); } } }
        private int _Direction;


        public int Cash { get { return _Cash; } set { if (_Cash != value) { _Cash = value; NotifyPropertyChanged(); } } }
        private int _Cash;

        public int Deposit { get { return _Deposit; } set { if (_Deposit != value) { _Deposit = value; NotifyPropertyChanged(); } } }
        private int _Deposit;

        public int Paypal { get { return _Paypal; } set { if (_Paypal != value) { _Paypal = value; NotifyPropertyChanged(); } } }
        private int _Paypal;

        public ObservableCollection<Card> CardCollection { get { return _CardCollection; } set { if (_CardCollection != value) { _CardCollection = value; NotifyPropertyChanged(); } } }
        private ObservableCollection<Card> _CardCollection;


        public int CardAmount { get { return _CardAmount; } set { if (_CardAmount != value) { _CardAmount = value; NotifyPropertyChanged(); } } }
        private int _CardAmount;


        public God God { get { return _God; } set { if (_God != value) { _God = value; NotifyPropertyChanged(); } } }
        private God _God;

        public TimeBomb TimeBomb { get { return _TimeBomb; } set { if (_TimeBomb != value) { _TimeBomb = value; NotifyPropertyChanged(); } } }
        private TimeBomb _TimeBomb;

        public Car Car { get { return _Car; } set { if (_Car != value) { _Car = value; NotifyPropertyChanged(); } } }
        private Car _Car;

        //public Brush Color { get { return _Color; } set { if (_Color != value) { _Color = value; NotifyPropertyChanged(); } } }
        //private Brush _Color;

        public bool IsAlive { get { return _IsAlive; } set { if (_IsAlive != value) { _IsAlive = value; NotifyPropertyChanged(); } } }
        private bool _IsAlive = true;



        public AbnormalState AbnormalState { get { return _AbnormalState; } set { if (_AbnormalState != value) { _AbnormalState = value; NotifyPropertyChanged(); } } }
        private AbnormalState _AbnormalState;



        public event Action<int> MoveEvent;
        public event Action<int> StrategyEvent;

        public void FreeAction()
        {

        }

        public void UIInputStrategy()
        {
            StrategyEvent?.Invoke(1);
        }

        public void UIInputMove()
        {
            MoveEvent?.Invoke(2);
        }
    }

}
