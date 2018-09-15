using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 加油站
    /// </summary>
    public class GasStation : CommercialAsset
    {
        public GasStation()
        {
            Level = 1;
            RentPrice = 0;
        }
    }
    
}
