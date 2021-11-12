using System.Collections;
using UnityEngine;

namespace Buildings
{
    public class MoneyGenerator : Building
    {
        public override void Place()
        {
            base.Place();
            StartCoroutine(GenerateMoneyCoroutine());
        }

        private IEnumerator GenerateMoneyCoroutine()
        {
            while (true)
            {
                Owner.PlayerInfo.Money += 10;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
