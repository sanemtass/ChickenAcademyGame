using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawn : MonoBehaviour
{
    public Transform spawn_1;
    public Transform spawn_2;
    public Transform spawn_3;

    private void OnEnable()
    {
        transform.position = new Vector3(Random.Range(spawn_1.position.x, spawn_3.position.x), 0.10f, Random.Range(spawn_2.position.z, spawn_1.position.z));
    }

    private void Start()
    {
        WormSpawnMechanic();
    }

    private void Update()
    {
        RespawnWorms();
    }

    private void WormSpawnMechanic()
    {
        for (int i = 0; i <= ObjectPooling.Instance.pools[0].poolSize; i++)
        {
            var obj = ObjectPooling.Instance.GetPoolObject(0);
            obj.transform.position = new Vector3(Random.Range(spawn_1.position.x, spawn_3.position.x), 0.10f, Random.Range(spawn_2.position.z, spawn_1.position.z));
            if (i <= 5)
            {
                obj.gameObject.GetComponent<WormLevel>().wormLevel = CharacterLevelSystem._currentLevel;
            }
            else
            {
                obj.gameObject.GetComponent<WormLevel>().wormLevel = Random.Range(1, 5);
            }
            if (obj.gameObject.GetComponent<WormLevel>().wormLevel == 1)
            {
                obj.transform.Find("Worm_Rig_bake_v1").localScale = Vector3.one * 5f;
            }
            else if (obj.gameObject.GetComponent<WormLevel>().wormLevel == 2)
            {
                obj.transform.Find("Worm_Rig_bake_v1").localScale = Vector3.one * 6f;
            }
            else if (obj.gameObject.GetComponent<WormLevel>().wormLevel == 3)
            {
                obj.transform.Find("Worm_Rig_bake_v1").localScale = Vector3.one * 7f;
            }
            else if (obj.gameObject.GetComponent<WormLevel>().wormLevel == 4)
            {
                obj.transform.Find("Worm_Rig_bake_v1").localScale = Vector3.one * 8f;
            }
        }
    }
    private void RespawnWorms()
    {
        foreach (var obj in ObjectPooling.Instance.pools[0].PooledObjects)
        {
            if (!obj.active)
            {
                SpawnRoutine(obj);
                break;
            }
        }
    }

    private void SpawnRoutine(GameObject obj)
    {
        obj.transform.position = new Vector3(Random.Range(spawn_1.position.x, spawn_3.position.x), 0.10f, Random.Range(spawn_2.position.z, spawn_1.position.z));
        obj.SetActive(true);
    }
}
