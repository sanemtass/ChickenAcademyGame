using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FarmerEnemyTarget : MonoBehaviour
{
    private GameObject[] spawnedWorkerChicken;
    public Transform closestWorkerChicken;
    public bool targetedWorkerChicken = false;
    public AIDestinationSetter aiDes;
    public FarmerCollision farmerCollision;
    public GameObject exit;

    private void Start()
    {
        closestWorkerChicken = null;
        targetedWorkerChicken = false;
    }

    private void Update()
    {
        closestWorkerChicken = getClosestChicken();
        aiDes.target = closestWorkerChicken;
      
        if (farmerCollision.isWorkerChickenTaken)
        {
            aiDes.target = exit.transform;
            Debug.Log("exit targetlandi");
        }
    }

    public Transform getClosestChicken()
    {
        spawnedWorkerChicken = GameObject.FindGameObjectsWithTag("WorkerChicken");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject workerChicken in spawnedWorkerChicken)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, workerChicken.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = workerChicken.transform;
                targetedWorkerChicken = true;
            }
        }
        return trans;
    } 
}
