using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerCollision : MonoBehaviour
{
    public GameObject tempWorkerChicken;
    public bool isWorkerChickenTaken = false;
    FarmerSpawn farmerSpawn;
    public bool isCatched;
    FarmerStack farmerStack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WorkerChicken") && !isCatched)
        {
            tempWorkerChicken = other.gameObject;
            isCatched = true;
            isWorkerChickenTaken = true;
            Debug.Log("Isci tavuga dokunuldu");
            ObjectPooling.Instance.SetPoolObject(other.gameObject, 3);
        }
        if (other.gameObject.CompareTag("ExitPoint"))
        {
            isCatched = false;
            Debug.Log("Exit pointe ulasildi");
            isWorkerChickenTaken = false;
            ObjectPooling.Instance.SetPoolObject(gameObject, 8);
        }
        if (other.gameObject.CompareTag("Player") && isCatched)
        {
            if (tempWorkerChicken != null)
            {
                isCatched = false;
                ObjectPooling.Instance.SetPoolObject(tempWorkerChicken, 3);
                var workerChicken = ObjectPooling.Instance.GetPoolObject(3);
                workerChicken.transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z + 2);
                tempWorkerChicken = null;
            }
        }
    }
}
