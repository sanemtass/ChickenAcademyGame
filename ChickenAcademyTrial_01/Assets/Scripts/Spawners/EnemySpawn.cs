using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemySpawnPoints = new List<GameObject>();
  

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemySpawnPoints.Count; i++)
        {
            var Enemy = ObjectPooling.Instance.GetPoolObject(1);
            Enemy.transform.position = EnemySpawnPoints[i].transform.position;
        }
       
    }    
}
