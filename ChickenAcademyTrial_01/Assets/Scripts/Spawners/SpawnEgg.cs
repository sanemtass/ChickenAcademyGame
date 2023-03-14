using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnEgg : MonoBehaviour
{

    public Transform collectPoint;
    //public PlayerCollision playerCollision;

    [SerializeField]
    int _stackHeight = 2;
    
    public static float stackCount;

    private void Update()
    {
        if (stackCount % 4 < 4 && stackCount >= 4)
        {
            stackCount = stackCount - 4;
            var Egg = ObjectPooling.Instance.GetPoolObject(1);
            float eggCount = ObjectPooling.Instance.pools[1].PooledObjects.Count + .2f;
            int rowCount = ObjectPooling.Instance.pools[1].PooledObjects.Count;
            Egg.transform.position = new Vector3(collectPoint.position.x + ((float)rowCount / 2), (eggCount % _stackHeight) / 2, collectPoint.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stackCount += PlayerCollision.targetProgress;
            PlayerCollision.targetProgress = 0;
            CoinSpawner.Instance.CoinSpawn();
        }
    }

}

