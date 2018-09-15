using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyWPF
{
    public enum GameState
    {
        FreeTime,
        /**
         * 1、自由时间：使用卡片，查看地图，数据统计等
         * 2、掷骰子时间：根据状态掷骰子
         * 3、定下来以后的顺序：
         *          a、查看地面状态：狗、炸弹、神、定时炸弹、宝箱、礼盒
         *          b、根据地的类型进行：休息、点券、空地、对手地产、自己地产、商店、医院监狱、游戏（暂无）
         * 4、对手时间
         */
    }
}
