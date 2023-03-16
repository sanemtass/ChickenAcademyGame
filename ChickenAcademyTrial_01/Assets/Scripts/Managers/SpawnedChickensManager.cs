using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedChickensManager : MonoBehaviour
{

    private static SpawnedChickensManager instance = null;
    public static SpawnedChickensManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SpawnedChickensManager").AddComponent<SpawnedChickensManager>();
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }

    public List<GameObject> WarriorChickens = new List<GameObject>();
    public List<GameObject> WorkerChickens = new List<GameObject>();

    private WarriorChicken _warriorChicken;
    private int indexPointOfWarriorChickens = 0;
    private int indexPointOfWorkerChickens = 0;

    public Transform armyZone = null;
    public Vector3 warriorChickenSpawnEulerAngles;
    public int maxWarriorChickenLimit = 10; //oyuna baslanilan savasci tavuk limitiyle degistirirsin.

   

    private void Start()
    {
        warriorChickenSpawnEulerAngles = this.transform.eulerAngles;
    }

    public int IndexPointOfWarriorChickens()
    {
        return indexPointOfWarriorChickens;
    }

    public int IndexPointOfWorkerChickens()
    {
        return indexPointOfWorkerChickens;
    }

    public int NumberOfWarriorChickens()
    {
        return WarriorChickens.Count;
    }

    public int NumberOfWorkerChickens()
    {
        return WorkerChickens.Count;
    }

    public void AddWarriorChickenList(GameObject warriorChicken)
    {
        WarriorChickens.Add(warriorChicken);
        indexPointOfWarriorChickens++;
    }

    public void AddWorkerChickenList(GameObject workerChicken)
    {
        WorkerChickens.Add(workerChicken);
        indexPointOfWorkerChickens++;
    }
}