using System;
using Photon.Pun;

namespace Global
{
    public static class PhotonHelper
    {
        public static Guid LocalPlayerId = Guid.Parse(PhotonNetwork.LocalPlayer.UserId);
    }
}
