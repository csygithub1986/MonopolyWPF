using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Card : ModelBase
    {
        public CardType CardType { get { return _CardType; } set { if (_CardType != value) { _CardType = value; NotifyPropertyChanged(); } } }
        private CardType _CardType;

        public int PaypalPrice { get { return _PaypalPrice; } set { if (_PaypalPrice != value) { _PaypalPrice = value; NotifyPropertyChanged(); } } }
        private int _PaypalPrice;

        public Card(CardType type, int price)
        {
            CardType = type;
            PaypalPrice = price;
        }
    }

}
