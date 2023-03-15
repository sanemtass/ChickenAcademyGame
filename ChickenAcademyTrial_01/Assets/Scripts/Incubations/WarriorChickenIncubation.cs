using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorChickenIncubation : MonoBehaviour
{
    public List<Transform> WaitingPoints = new List<Transform>();
    public float RespawnCount = 5f;
    public WarriorIncubator warriorIncubator;
    private Transform waitingPoint;
    private Coroutine generateRoutine;

    [SerializeField] private SpawnedChickensManager spawnedChickensManager;

    private void Start()
    {
        if (spawnedChickensManager.NumberOfWarriorChickens() < WaitingPoints.Count)
        {
            StartGenerate();
        }
    }

    public void StartGenerate()
    {
        generateRoutine = StartCoroutine(GenerateWarriorChicken());
    }

    public void StopGenerate()
    {
        StopCoroutine(generateRoutine);
    }

    private IEnumerator GenerateWarriorChicken()
    {
        while (spawnedChickensManager.IndexPointOfWarriorChickens() < WaitingPoints.Count)
        {
            yield return new WaitForSeconds(RespawnCount);

            if (WarriorIncubator.tempEgg > 0)
            {
                var index = spawnedChickensManager.IndexPointOfWarriorChickens();
                waitingPoint = WaitingPoints[index];

                var Egg = warriorIncubator.EggsOnIncubator.Dequeue();

                Egg.transform.parent = GameObject.Find("Egg (UnityEngine.GameObject)").transform;
                ObjectPooling.Instance.SetPoolObject(Egg, 1);
                warriorIncubator.tempObject = ObjectPooling.Instance.GetPoolObject(2);
                WarriorIncubator.tempEgg--;

                spawnedChickensManager.AddWarriorChickenList(warriorIncubator.tempObject.gameObject);
                warriorIncubator.tempObject.transform.position = transform.position + Vector3.forward * 2;
                warriorIncubator.tempObject.GetComponent<WarriorChicken>().MoveToPoint(waitingPoint);

            }
        }
    }
}
