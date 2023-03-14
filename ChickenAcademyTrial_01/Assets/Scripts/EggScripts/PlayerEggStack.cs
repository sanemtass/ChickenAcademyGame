using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEggStack : MonoBehaviour
{
    public int eggStackLimit;
    public bool isStacking = true;
    public bool eggCollected;
    public Transform stackPoint;
    public Queue<GameObject> EggsOnPlayer = new Queue<GameObject>();
    public bool hasStack;
    bool onIncTrigger;
    public static int tempEgg;
    private static PlayerEggStack instance = null;
    public static PlayerEggStack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Player").AddComponent<PlayerEggStack>();
            }
            return instance;
        }
    }
    private void Start()
    {
        StartCoroutine(DestroyEggs());
    }
    public void Update()
    {
        eggStackLimit = UIManager.Instance.playerEggStackLimit;
        if (EggsOnPlayer.Count > 0)
        {
            hasStack = true;
        }
        else
        {
            hasStack = false;
        }
        if (!onIncTrigger)
        {
            StopCoroutine(DestroyEggs());
        }
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EggCollectArea"))
        {
            if (isStacking && EggCreaterManager.tempEgg > 0)
            {
                var Egg = ObjectPooling.Instance.GetPoolObject(1);
                Egg.transform.parent = gameObject.transform;
                Egg.transform.position = new Vector3(stackPoint.position.x, (float)EggsOnPlayer.Count, stackPoint.position.z);
                EggsOnPlayer.Enqueue(Egg);
                eggCollected = true;
                Debug.Log(eggCollected);
                EggCreaterManager.tempEgg--;
                tempEgg++;
                if (EggsOnPlayer.Count >= eggStackLimit)
                {
                    isStacking = false;
                }
            }
            else if (EggsOnPlayer.Count < eggStackLimit)
            {
                isStacking = true;
            }
        }
        if (other.gameObject.CompareTag("WorkerIncubator")||other.gameObject.CompareTag("WarriorIncubator"))
        {
            onIncTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WorkerIncubator") || other.gameObject.CompareTag("WarriorIncubator"))
        {
            onIncTrigger = false;
        }
    }
    IEnumerator DestroyEggs()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (EggsOnPlayer.Count > 0 && onIncTrigger)
            {
                var Egg = EggsOnPlayer.Dequeue();
                Egg.transform.parent = GameObject.Find("Egg (UnityEngine.GameObject)").transform;
                ObjectPooling.Instance.SetPoolObject(Egg, 1);
            }
        }                
    }  
}