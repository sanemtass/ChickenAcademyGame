using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinSpawnPoint;
    private static CoinSpawner instance = null;
    public Queue<GameObject> Coins = new Queue<GameObject>();
    public static CoinSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CoinSpawner").AddComponent<CoinSpawner>();
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }

    public void CoinSpawn()
    {
        var coin = ObjectPooling.Instance.GetPoolObject(5);
        coin.transform.position = CoinSpawnPoint.transform.position;
        Coins.Enqueue(coin);
    }
    public void CoinDestroy()
    {
        var coin = Coins.Dequeue();
        ObjectPooling.Instance.SetPoolObject(coin, 5);
    }
}
