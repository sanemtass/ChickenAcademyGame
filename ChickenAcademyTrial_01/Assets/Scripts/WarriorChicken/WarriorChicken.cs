using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WarriorChicken : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;
    private Transform target;
    private Gun gunShoot;
    private FindClosestEnemy findClosestEnemy;

    public float fireTime = 0.3f;
    public float reloadTimesss = 1f;
    public int reloadWaitTime = 1;
    private float totalFireTime = 0f;
    private float totalReloadTime = 0f;

    public float attackRange = 10f;

    public enum WarriorChickenStates
    {
        Waiting,
        Moving,
        Fighting
    }

    public WarriorChickenStates warriorChickenState = WarriorChickenStates.Waiting;

    private void Start()
    {
        findClosestEnemy = GetComponent<FindClosestEnemy>();
        gunShoot = GetComponent<Gun>();
    }

    private void Update()
    {
        Move();
        if (colliderController.onBattle)
        {
            warriorChickenState = WarriorChickenStates.Fighting;
        }
    }

    public void MoveToPoint(Transform targetPoint)
    {
        warriorChickenState = WarriorChickenStates.Moving;
        target = targetPoint;
    }

    private void Move()
    {
        destinationSetter.target = target;

        if (warriorChickenState == WarriorChickenStates.Fighting && findClosestEnemy.closestEnemy != null)
        {
            transform.LookAt(findClosestEnemy.closestEnemy.transform.position);
            destinationSetter.target = findClosestEnemy.closestEnemy;
            MyInput();
        }

        if (warriorChickenState == WarriorChickenStates.Moving)
        {
            destinationSetter.target = target;
            warriorChickenState = WarriorChickenStates.Waiting;
        }
    }

    public void MyInput()
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
