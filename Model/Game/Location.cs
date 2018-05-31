using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 位置
    /// </summary>
    public class Location
    {
        public int Index { get; set; }

        public LocationType LocationType { get; set; }

        public object Content { get; set; }
    }

  
}
