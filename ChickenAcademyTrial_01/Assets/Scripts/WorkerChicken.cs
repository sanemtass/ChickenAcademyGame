using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WorkerChicken : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;

    private Transform target;
    public GameObject motherChicken;
    public int wormCount = 0;
    public int wormMaxCount;
    public bool getWorm;

    private void Update()
    {
        wormMaxCount = UIManager.Instance.workerChickenStackCount;
        Move();
    }

    public void MoveToPoint(Transform targetPoint)
    {
        target = targetPoint;
    }

    private void Move()
    {
        destinationSetter.target = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Worm"))
        {
            if (wormCount == wormMaxCount)
            {
                getWorm = true;
            }
            wormCount++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Mother"))
        {
            getWorm = false;
            SpawnEgg.stackCount += wormCount;
            wormCount = 0;
            CoinSpawner.Instance.CoinSpawn();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Worm"))
        {
            if (other.gameObject.GetComponent<WormLevel>().wormLevel == 1)
            {
                getWorm = true;
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.GetComponent<WormLevel>().wormLevel != 1)
            {

            }
        }
    }
}
