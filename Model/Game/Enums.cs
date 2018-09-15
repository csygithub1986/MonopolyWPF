using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum CardType
    {
        乌龟卡,
        购地卡,
        遥控骰子,
        路障卡,
        机车卡,
        汽车卡,
        换地卡,
        换屋卡,
        机器娃娃,
        地雷卡,
        定时炸弹,
        飞弹卡,
        机器工人,
        传送机,
        穿梭宝剑,
        工程车,
        拆除卡,
        改建卡,
        怪兽卡,
        恶魔卡,
        天使卡,
        查封卡,
        涨价卡,
        均贫卡,
        均富卡,
        同盟卡,
        免罪卡,
        请神符,
        送神符,
        免费卡,
        停留卡,
        查税卡,
        抢夺卡,
        真抢夺卡,
        复仇卡,
        陷害卡,
        嫁祸卡,
        梦游卡,
        冬眠卡,
        //拍卖卡,
        //红卡,
        //黑卡
    }

    public enum GodType
    {
        福神,
        土地公公
    }

    //位置类型
    public enum LocationType
    {
        无,
        住宅地产,
        商业地产,
        点券,
        银行,
        商店,
        医院,
        监狱
        //魔法屋,
        //新闻,
        //机会
    }

    //地产类型
    //public enum LandType
    //{
    //    住宅用地, 商业用地
    //}

    /// <summary>
    /// 住宅建筑类型
    /// </summary>
    public enum ResidenceBuildingType
    {

    }

    /// <summary>
    /// 商业建筑类型
    /// </summary>
    public enum CommercialBuildingType
    {
        无,
        公园,
        研究所,
        加油站,
        连锁超市,
        饭店
    }

    public enum CarType
    {
        机车,
        汽车
    }

    /// <summary>
    /// 异常状态类型
    /// </summary>
    public enum AbnormalState
    {
        无,
        进医院,
        进监狱,
        住酒店,
        睡眠,
        梦游
    }
}
