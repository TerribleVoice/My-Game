using System;
using System.Collections.Generic;
using Global;
using Photon.Pun;

namespace Multiplayer
{
    public static class PlayerList
    {
        private static readonly Dictionary<Guid, Player> players = new Dictionary<Guid, Player>();

        public static Player GetPlayer(Guid playerId)
        {
            if (!players.ContainsKey(playerId))
                throw new InvalidOperationException($"Игрок с Id {playerId} не найден");

            return players[playerId];
        }

        public static void CreatePlayer(Guid playerId, string nickname, Player playerObject)
        {
            if (players.ContainsKey(playerId))
                throw new InvalidOperationException($"Игрок с Id {playerId} уже существует");

            playerObject.PlayerInfo = new PlayerInfo
                {
                    Id = playerId,
                    Money = GameConstants.StartMoney,
                    IncomeMultiplier = 1,
                    NickName = nickname
                };

            players.Add(playerId, playerObject);
        }

        public static Player GetLocalPlayer()
        {
            return GetPlayer(PhotonHelper.LocalPlayerId);
        }
    }
}
