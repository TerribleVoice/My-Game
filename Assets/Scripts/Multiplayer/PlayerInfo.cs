using System;
using System.Collections.Generic;
using Buildings;
using Global;
using Photon.Pun;

namespace Multiplayer
{
    public class PlayerInfo
    {
        public string NickName;
        public Guid Id;
        public int Money;
        public float IncomeMultiplier;
        public List<Building> Buildings;

        public PlayerInfo()
        {
            Id = Guid.Parse(PhotonNetwork.LocalPlayer.UserId);
            Money = GlobalConstants.StartMoney;
            IncomeMultiplier = 1;
            NickName = PhotonNetwork.NickName;
        }
    }
}
