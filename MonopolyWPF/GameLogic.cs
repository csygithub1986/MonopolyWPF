using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyWPF
{
    public class GameLogic : ModelBase
    {
        public Map Map { get { return _Map; } set { if (_Map != value) { _Map = value; NotifyPropertyChanged(); } } }
        private Map _Map;

        public Player[] Players { get { return _Players; } set { if (_Players != value) { _Players = value; NotifyPropertyChanged(); } } }
        private Player[] _Players;

        public Player CurrentPlayer { get { return _CurrentPlayer; } set { if (_CurrentPlayer != value) { _CurrentPlayer = value; NotifyPropertyChanged(); } } }
        private Player _CurrentPlayer;

        public event Action<List<int>> MoveEvent;

        public void Start()
        {
            CurrentPlayer = Players[0];
            CurrentPlayer.FreeAction();
        }

        public void Init(Map map)
        {
            //TODO：加载地图
            Map = map;

            //Map = new Map();
            //Map.LocationCollection = new Collection<Location>();
            //for (int i = 0; i < 20; i++)
            //{
            //    Map.LocationCollection.Add(new Location() { Index = i });
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    int forwardIndex = i + 1 > 19 ? 0 : i + 1;
            //    int backwardIndex = i - 1 < 0 ? 19 : i - 1;
            //    Location forward = Map.LocationCollection.First(p => p.Index == forwardIndex);
            //    Location backward = Map.LocationCollection.First(p => p.Index == backwardIndex);
            //    Map.LocationCollection.First(p => p.Index == i).RoadInfos.Add(new RoadInfo()
            //    {
            //        RoadIndex = 0,
            //        //ForwardLocation = forward,
            //        //BackwardLocation = backward
            //    });
            //}


            //初始化玩家
            Random ran = new Random();
            Players = new Player[2];
            for (int i = 0; i < 2; i++)
            {
                Location loc = Map.LocationCollection[ran.Next(Map.LocationCollection.Count)];
                Players[i] = new Player()
                {
                    ID = i,//TODO: ID随机分配
                    CardCollection = new ObservableCollection<Card>()
                    {
                        SystemStaticData.Default.NewCard(CardType.遥控骰子),
                        SystemStaticData.Default.NewCard(CardType.路障卡),
                        SystemStaticData.Default.NewCard(CardType.机车卡),
                    },
                    Cash = 50000,
                    Deposit = 50000,
                    Location = loc,
                    RoadIndex = loc.RoadInfos.First().RoadIndex,
                    Direction = ran.Next(2) == 0 ? 1 : -1,
                    Paypal = 50,
                    Role = SystemStaticData.Default.RoleCollection[i]
                };
                Players[i].MoveEvent += MoveAction;
                Players[i].StrategyEvent += StrategyAction; ;
            }
            //Players = players;
        }

        private void StrategyAction(int obj)
        {
            Console.WriteLine(CurrentPlayer.Role.Name + "使用卡片");
        }

        private void MoveAction(int obj)
        {
            List<int> routeList = new List<int>();//记录下经过的路径
            routeList.Add(CurrentPlayer.Location.Index);

            Random ran = new Random();
            int step = ran.Next(1, 7);

            //执行Move
            int roadIndex = CurrentPlayer.RoadIndex;
            int direction = CurrentPlayer.Direction;
            var location = CurrentPlayer.Location;
            for (int i = 0; i < step; i++)
            {
                Location tempLocation = null;
                int tempDirection = direction;
                int tempRoadIndex = roadIndex;

                //同一条线路往前走
                RoadInfo sameRoad = location.RoadInfos.First(p => p.RoadIndex == roadIndex);
                tempLocation = direction == 1 ? sameRoad.ForwardLocation : sameRoad.BackwardLocation;
                //三岔路时，随机走（必须是三岔路，即另一条路的两个方向都必须是有路的）
                if (tempLocation == null)
                {
                    tempDirection = ran.Next(2) == 0 ? -1 : 1;
                    RoadInfo otherRoad = location.RoadInfos.First(p => p.RoadIndex != roadIndex);
                    tempRoadIndex = otherRoad.RoadIndex;
                    tempLocation = tempDirection == 1 ? otherRoad.ForwardLocation : otherRoad.BackwardLocation;
                    //死胡同时
                    if (tempLocation == null)
                    {
                        tempRoadIndex = roadIndex;
                        tempDirection = -direction;
                        tempLocation = tempDirection == 1 ? sameRoad.ForwardLocation : sameRoad.BackwardLocation;
                    }
                }

                direction = tempDirection;
                location = tempLocation;
                roadIndex = tempRoadIndex;

                routeList.Add(location.Index);
            }

            CurrentPlayer.RoadIndex = roadIndex;
            CurrentPlayer.Direction = direction;
            CurrentPlayer.Location = location;

            //UI动画
            MoveEvent?.Invoke(routeList);


        }

        /// <summary>
        /// 运动完
        /// </summary>
        public void MoveOver()
        {
            //TODO：Move后逻辑

            ChangeTurn();
            CurrentPlayer.FreeAction();
        }



        public void ChangeTurn()
        {
            int tempID = CurrentPlayer.ID;
            for (int i = 0; i < Players.Length; i++)
            {
                tempID++;
                if (tempID >= Players.Length)
                {
                    tempID = 0;
                }
                if (Players[tempID].ID != CurrentPlayer.ID && Players[tempID].IsAlive)
                {
                    CurrentPlayer = Players[tempID];
                    return;
                }
            }
            Log.WriteLog("切换用户出错");
        }


        private void BeforeMove()
        {

        }

        private void Move()
        {

        }

        private void AfterMove()
        {

        }

        #region 单例
        public static GameLogic Default;
        static GameLogic()
        {
            Default = new GameLogic();
        }
        #endregion
    }
}
