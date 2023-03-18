using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject _exitPoint;

    public Queue<GameObject> EnemyFarmer = new Queue<GameObject>();
    public GameObject _spawnPoint;
    SpawnedChickensManager spawnedChickensManager;
    public bool isFarmerSpawned = false;

    private static FarmerSpawn instance = null;
    public static FarmerSpawn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("EnemyFarmerSpawner").AddComponent<FarmerSpawn>();
            }
            return instance;
        }
    }
    public float enemyFarmerSpawnTime;
    public float enemyFarmerSpawnRate;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", enemyFarmerSpawnTime, enemyFarmerSpawnRate);
    }
  
    private void SpawnEnemy()
    {
        var farmerEnemy = ObjectPooling.Instance.GetPoolObject(7);
        EnemyFarmer.Enqueue(farmerEnemy);
        farmerEnemy.transform.position = new Vector3(_spawnPoint.transform.position.x, _spawnPoint.transform.position.y, _spawnPoint.transform.position.z);
        isFarmerSpawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitPoint"))
        {
            var farmerEnemy = EnemyFarmer.Dequeue();
            ObjectPooling.Instance.SetPoolObject(farmerEnemy, 7);
            isFarmerSpawned = false;
        }
    }
}
