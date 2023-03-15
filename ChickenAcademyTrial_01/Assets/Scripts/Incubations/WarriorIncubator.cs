using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorIncubator : MonoBehaviour
{
    public Transform incubatorPoint;

    public Queue<GameObject> EggsOnIncubator = new Queue<GameObject>();

    private bool isIncubatorWorking=true;
    private bool canGiveEgg;

    public int incubatorEggLimit;
    public int incubatorSpawnTime;
    public static int tempEgg;

    public GameObject spawnPoint;
    public GameObject tempObject;

    private void Start()
    {
        StartCoroutine(GiveEgg());
    }

    private void Update()
    {
        incubatorEggLimit = UIManager.Instance.incubatorEggLimit;
        incubatorSpawnTime = UIManager.Instance.incubatorSpawnTime;
        if (PlayerEggStack.tempEgg <= 0)
        {
            canGiveEgg = false;
            StopCoroutine(GiveEgg());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canGiveEgg = true;
        }
    }
  
    private IEnumerator GiveEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (canGiveEgg)
            {
                if (isIncubatorWorking && PlayerEggStack.tempEgg > 0) 
                {
                    var Egg = ObjectPooling.Instance.GetPoolObject(1);
                    Egg.transform.position = new Vector3(incubatorPoint.position.x, 1f + (float)EggsOnIncubator.Count / 2, incubatorPoint.position.z);
                    EggsOnIncubator.Enqueue(Egg);
                    Egg.transform.parent = gameObject.transform;
                    PlayerEggStack.tempEgg--;
                    tempEgg++;

                    if (EggsOnIncubator.Count >= incubatorEggLimit)
                    {
                        isIncubatorWorking = false;
                    }
                }
                else if (EggsOnIncubator.Count < incubatorEggLimit)
                {
                    isIncubatorWorking = true;
                }
            }
        }

        if (isIncubatorWorking && PlayerEggStack.tempEgg > 0) 
        {
            var Egg = ObjectPooling.Instance.GetPoolObject(1);
            Egg.transform.position = new Vector3(incubatorPoint.position.x, 1f + (float)EggsOnIncubator.Count / 2, incubatorPoint.position.z);
            EggsOnIncubator.Enqueue(Egg);
            Egg.transform.parent = gameObject.transform;
            PlayerEggStack.tempEgg--;
            tempEgg++;

            if (EggsOnIncubator.Count >= incubatorEggLimit)
            {
                isIncubatorWorking = false;
            }
        }

        else if (EggsOnIncubator.Count < incubatorEggLimit)
        {
            isIncubatorWorking = true;
        }
    }
}

