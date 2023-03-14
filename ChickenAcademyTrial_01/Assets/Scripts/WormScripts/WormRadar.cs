using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormRadar : MonoBehaviour
{
    private GameObject[] spawnedWorms;
    public GameObject obj;
    public Transform closestWorm;
    public bool targetedWorm;
    public AIDestinationSetter aiDes;
    public WorkerChicken workerChicken;
    public GameObject mother;
    void Start()
    {
        closestWorm = null;
        targetedWorm = false;
    }
    private void LateUpdate()
    {
        //obj.transform.position = closestWorm.position;
        if (!workerChicken.getWorm)
        {
            closestWorm = getClosestWorm();
            aiDes.target = closestWorm;
        }
        else
        {
            aiDes.target = mother.transform;
        }
        
        
        //transform.position = closestWorm.transform.position;
    }
    public Transform getClosestWorm()
    {
        spawnedWorms = GameObject.FindGameObjectsWithTag("Worm");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject worm in spawnedWorms)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, worm.transform.position);
            if (currentDistance<closestDistance)
            {
                closestDistance = currentDistance;
                trans = worm.transform;
              
            }
        }
        return trans;
    } //(1,2,5)
}
