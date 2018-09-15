using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPlayer
    {
        /// <summary>
        /// 游戏控制器调用。如果是AI，做动作决策
        /// </summary>
        void FreeAction();

        event Action<int> MoveEvent;

        event Action<int> StrategyEvent;
    }
}
