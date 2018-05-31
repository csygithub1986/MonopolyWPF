using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonopolyServer
{
    public class MonopolyService : IMonopolyService
    {
        public void ApplyToJoinGame(string gameID, int playerID)
        {
            throw new NotImplementedException();
        }

        public void ClientCommitMove(string gameID, int stepNum, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void CreateGame(Player[] players, GameSetting gameSettign)
        {
            throw new NotImplementedException();
        }

        public void GameStart()
        {
            throw new NotImplementedException();
        }

        public void GetAllGames()
        {
            throw new NotImplementedException();
        }

        public string Login(string account)
        {
            throw new NotImplementedException();
        }
    }
}
