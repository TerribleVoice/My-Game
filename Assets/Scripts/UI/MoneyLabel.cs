using System;
using Multiplayer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoneyLabel : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        public void Update()
        {
            text.text = $"Money {Local.Player.PlayerInfo.Money}";
        }
    }
}
