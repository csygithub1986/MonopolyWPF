using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 公园
    /// </summary>
    public class Park : CommercialAsset
    {
        public Park()
        {
            Level = 1;
            RentPrice = 0;
        }
    }
    
}
