using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonopolyServer
{
    [ServiceContract]
    public interface IMonopolyService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>返回sessionID</returns>
        [OperationContract]
        string Login(string account);

        /// <summary>
        /// 异步请求所有列表
        /// </summary>
        [OperationContract]
        void GetAllGames();

        [OperationContract]
        void CreateGame(Player[] players, GameSetting gameSettign);


        [OperationContract]
        void ApplyToJoinGame(string gameID, int playerID);

        /// <summary>
        /// Host发送开始游戏
        /// </summary>
        [OperationContract]
        void GameStart();

        /// <summary>
        /// client提交Move
        /// </summary>
        /// <param name="stepNum"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [OperationContract]
        void ClientCommitMove(string gameID, int stepNum, int x, int y);
    }

}
