using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FindClosestEnemy : MonoBehaviour
{
    public Transform closestEnemy;
   
    private GameObject[] spawnedEnemys;
    private void Start()
    {
        closestEnemy = null;
    }

    private void Update()
    {
        
        closestEnemy = GetClosestEnemy();
        if (colliderController.onBattle && !gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AIPath>().slowdownDistance = 5;
            gameObject.GetComponent<AIPath>().endReachedDistance = 7;
        }
        if (closestEnemy == null && !gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AIPath>().slowdownDistance = 1.5f;
            gameObject.GetComponent<AIPath>().endReachedDistance = 2.5f;
        }
    }


    public Transform GetClosestEnemy()
    {
        spawnedEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        float closestEnemyDistance = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject enemy in spawnedEnemys)
        {
            try
            {
                float currentDistance;
                currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (currentDistance < closestEnemyDistance)
                {
                    closestEnemyDistance = currentDistance;
                    trans = enemy.transform;
                }
            }
            catch
            {
                
            }
        }
        return trans;
    }

}
