using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Map
    {
        public string MapGraph { get; set; }

        public Collection<Location> LocationCollection { get; set; }

        public static void DeserializeMap(Map map)
        {
            foreach (var location in map.LocationCollection)
            {
                foreach (var road in location.RoadInfos)
                {
                    if (road.ForwardLocationIndex == -1)
                    {
                        road.ForwardLocation = null;
                    }
                    else
                    {
                        road.ForwardLocation = map.LocationCollection.First(p => p.Index == road.ForwardLocationIndex);
                    }
                    if (road.BackwardLocationIndex == -1)
                    {
                        road.BackwardLocation = null;
                    }
                    else
                    {
                        road.BackwardLocation = map.LocationCollection.First(p => p.Index == road.BackwardLocationIndex);
                    }
                }
            }
        }
    }
}
