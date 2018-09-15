using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 研究院
    /// </summary>
    public class Institute : CommercialAsset
    {
        public Institute()
        {
            Level = 1;
            RentPrice = 0;
        }
    }
    
}
