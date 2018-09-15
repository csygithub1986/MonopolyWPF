using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MonopolyWPF
{
    public class SystemStaticData : ModelBase
    {
        public Dictionary<CardType, int> CardPricesDictionary { get { return _CardPricesDictionary; } set { if (_CardPricesDictionary != value) { _CardPricesDictionary = value; NotifyPropertyChanged(); } } }
        private Dictionary<CardType, int> _CardPricesDictionary = new Dictionary<CardType, int>();


        public ObservableCollection<Role> RoleCollection { get { return _RoleCollection; } set { if (_RoleCollection != value) { _RoleCollection = value; NotifyPropertyChanged(); } } }
        private ObservableCollection<Role> _RoleCollection = new ObservableCollection<Role>();


        public Card NewCard(CardType type)
        {
            return new Card(type, CardPricesDictionary[type]);
        }

        private SystemStaticData()
        {
            for (int i = 0; i < (int)CardType.冬眠卡; i++)
            {
                CardPricesDictionary.Add((CardType)i, 60);
            }
            //TODO：卡片全部定价

            RoleCollection.Add(new Role() { ID = 0, Name = "孙小美", Color = Brushes.Red });
            RoleCollection.Add(new Role() { ID = 1, Name = "沙隆巴斯", Color = Brushes.Yellow });
            //TODO：添加全部人物
        }

        public static SystemStaticData Default;
        static SystemStaticData()
        {
            Default = new SystemStaticData();
        }
    }
}
