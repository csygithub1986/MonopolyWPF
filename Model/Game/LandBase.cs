using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 地产
    /// </summary>
    public class Land
    {
        //public LandType LandType { get; set; }
        public int Level { get; set; }
        public int[] Prices { get; set; }
        public int[] RentPrices { get; set; }
        //public int BelongID { get; set; }

        public Player PlayerBelongTo { get; set; }
    }
}
