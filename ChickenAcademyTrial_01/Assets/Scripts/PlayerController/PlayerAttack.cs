using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAttack : MonoBehaviour
{
    public float fireTime = 0.3f;
    public float reloadTimesss = 1f;
    public int reloadWaitTime = 1;
    private float totalFireTime = 0f;
    private float totalReloadTime = 0f;
    private Gun gunShoot;
    private FindClosestEnemy findClosestEnemy;
    public float attackRange = 12f;

    private void Start()
    {
        findClosestEnemy = GetComponent<FindClosestEnemy>();
        gunShoot = GetComponent<Gun>();
       
    }
    private void Update()
    {
        if (colliderController.onBattle)
        {
            if(findClosestEnemy.closestEnemy != null)
            {
                totalFireTime += Time.deltaTime;
                if (GetDistance())
                {
                    if (totalFireTime > fireTime && totalReloadTime < reloadTimesss)
                    {
                        gunShoot.Shoot();
                        totalFireTime = 0f;
                    }

                    totalReloadTime += Time.deltaTime;
                }
                if (totalReloadTime > reloadTimesss)
                {
                    ResetReloadTime(reloadWaitTime);
                }
            }
            
        }
    }

    public bool GetDistance()
    {
        if (findClosestEnemy.closestEnemy != null)
        {
            bool isRange = Vector3.Distance(transform.position, findClosestEnemy.closestEnemy.transform.position) <= attackRange;
            return isRange;
        }
        return false;
    }


    private async void ResetReloadTime(int time)
    {
        await System.Threading.Tasks.Task.Delay(1000 * time);
        totalReloadTime = 0f;
    }
}
