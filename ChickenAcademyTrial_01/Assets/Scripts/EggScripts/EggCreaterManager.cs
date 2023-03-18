using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCreaterManager : MonoBehaviour
{
    //singleton haline getirilecek yumurtadaki scripten bu scripte erisilecek.
    //Ilk kez yumurta olusturulan script. Step-1

    GameObject Egg;
    public Transform spawnPoint;
    public Queue<GameObject> EggsMother = new Queue<GameObject>();
    bool isCreaterWorking = true;
    public int eggLimit = 18;
    public int stackCount = 6;
    public int eggCount = 0;
    public static int tempEgg=0;
    private static EggCreaterManager instance = null;
    public static EggCreaterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MotherChicken").AddComponent<EggCreaterManager>();
            }
            return instance;
        }
    }

    private void Update()
    {
        DestroyEgg();
       
    }

    public int EggCount()
    {
        if (PlayerCollision.targetProgress >= 4)
        {
            eggCount++;
            PlayerCollision.targetProgress -= 4;
        }
        return eggCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WorkerChicken"))
        {
            SpawnEgg();
        }
        if (other.gameObject.CompareTag("Player"))
        {

            if (PlayerCollision.targetProgress > 0)
            {
                for (int i = 0; i < EggCount(); i++)
                {
                    SpawnEgg();
                }
                eggCount = 0;
            }
        }
    }

    public void DestroyEgg()
    {
        if (EggsMother.Count > 0 && PlayerEggStack.Instance.eggCollected == true)
        {
            Egg = EggsMother.Dequeue();

            ObjectPooling.Instance.SetPoolObject(Egg, 1);
        }

    }

    public void SpawnEgg()
    {
        if (isCreaterWorking)
        {
            Egg = ObjectPooling.Instance.GetPoolObject(1);
            Egg.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            tempEgg++;
                
            EggsMother.Enqueue(Egg);


            if (EggsMother.Count >= eggLimit)
            {
                isCreaterWorking = false;
            }
        }

        if (EggsMother.Count < eggLimit)
        {
            isCreaterWorking = true;
        }
    }
}
