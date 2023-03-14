using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerChickenIncubation : MonoBehaviour
{
    [SerializeField] private SpawnedChickensManager spawnedChickensManager;
    public List<Transform> WormPoints = new List<Transform>();
    
    public float RespawnCount = 5f;
    private Coroutine generateRoutine;
    private Transform wormPoint;
    private void Start()
    {
        if (spawnedChickensManager.NumberOfWorkerChickens() < WormPoints.Count)
        {
            StartGenerate();
        }
    }

    public void StartGenerate()
    {
        generateRoutine = StartCoroutine(GenerateWorkerChicken());
    }

    public void StopGenerate()
    {
        StopCoroutine(generateRoutine);
    }

    private IEnumerator GenerateWorkerChicken()
    {
        while (spawnedChickensManager.IndexPointOfWorkerChickens() < WormPoints.Count)
        {
            yield return new WaitForSeconds(RespawnCount);
            if (EggStackWorkerInc._currentEggStack > 0)
            {
                var index = spawnedChickensManager.IndexPointOfWorkerChickens();
                wormPoint = WormPoints[index];
                var generateWorkerChicken = ObjectPooling.Instance.GetPoolObject(3);
                spawnedChickensManager.AddWorkerChickenList(generateWorkerChicken.gameObject);
                generateWorkerChicken.transform.position = transform.position + Vector3.forward * 2;
                generateWorkerChicken.GetComponent<WorkerChicken>().MoveToPoint(wormPoint);
                EggStackWorkerInc._currentEggStack--;
            }            
        }

    }

}
