using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class Player
    {
        //轮次
        public int TurnID { get; set; }

        //角色
        public Role Role { get; set; }

        public int LocationIndex { get; set; }

        public int Cash { get; set; }

        public int Deposit { get; set; }

        public int Paypal { get; set; }

        public List<Card> Cards { get; set; }

        public God God { get; set; }

        public int TotalPosit { get; set; }

        public Brush Color { get; set; }
    }

}
