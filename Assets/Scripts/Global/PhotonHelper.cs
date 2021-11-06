using System;
using Photon.Pun;

namespace Global
{
    public static class PhotonHelper
    {
        public static readonly Guid LocalPlayerId = Guid.Parse(PhotonNetwork.LocalPlayer.UserId);
    }
}
