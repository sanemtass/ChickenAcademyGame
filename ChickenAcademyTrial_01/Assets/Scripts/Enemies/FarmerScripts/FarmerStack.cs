using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerStack : MonoBehaviour
{
    Animator anim;
    public Transform stackPoint;
    public bool isWorkerStacked=false;
    public Queue<GameObject> WorkerChicken = new Queue<GameObject>();
    
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WorkerChicken")&& !isWorkerStacked)
        {
            anim.SetBool("Carry", true);
            var workerChicken = ObjectPooling.Instance.GetPoolObject(3);
            gameObject.GetComponent<FarmerCollision>().tempWorkerChicken = workerChicken;
            WorkerChicken.Enqueue(workerChicken);
            workerChicken.transform.parent = gameObject.transform;
            workerChicken.transform.position = new Vector3(stackPoint.position.x, stackPoint.position.y, stackPoint.position.z);
            isWorkerStacked = true;        
        }
        if (other.gameObject.CompareTag("ExitPoint"))
        {
            var workerChicken = WorkerChicken.Dequeue();
            workerChicken.transform.parent = GameObject.Find("WorkerChickenBase (UnityEngine.GameObject)").transform;
            ObjectPooling.Instance.SetPoolObject(workerChicken, 3);
            isWorkerStacked = false;
        }
    }
}
