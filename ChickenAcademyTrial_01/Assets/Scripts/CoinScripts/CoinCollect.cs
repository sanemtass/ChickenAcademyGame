using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RewardManager.Instance.RewardPileOfCoin(10);
            CoinSpawner.Instance.CoinDestroy();
        }
    }
}
