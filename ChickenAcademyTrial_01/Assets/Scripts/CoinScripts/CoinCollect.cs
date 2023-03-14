using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        RewardManager.Instance.RewardPileOfCoin(10);
    //        Debug.Log("Player dokundu");
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RewardManager.Instance.RewardPileOfCoin(10);
            Debug.Log("Player dokundu");
            CoinSpawner.Instance.CoinDestroy();
        }
    }
}
