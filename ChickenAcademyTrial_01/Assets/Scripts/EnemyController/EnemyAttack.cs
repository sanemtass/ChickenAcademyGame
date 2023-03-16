using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float fireTime = 0.3f;
    public float reloadTimesss = 1f;
    public int reloadWaitTime = 1;
    private float totalFireTime = 0f;
    private float totalReloadTime = 0f;

    public float attackRange = 12f;

    public Transform closestChicken;
    public GameObject player;
    Animator anim;
    private Gun gunShoot;

    //public Transform warriorChicken;
    private GameObject[] spawnedChickens;

    private void Start()
    {
        gunShoot = GetComponent<Gun>();
        closestChicken = null;
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        closestChicken = GetClosestChicken();
        MyInput();
    }

    public void MyInput()
    {
        if (colliderController.onBattle)
        {
            totalFireTime += Time.deltaTime;

            if (GetDistance() || GetDistancePlayer())
            {

                if (totalFireTime > fireTime && totalReloadTime < reloadTimesss)
                {
                    gunShoot.Shoot();
                    Debug.Log("Ateş ediyor");
                    totalFireTime = 0f;

                    //else
                    //{
                    //    anim.SetBool("EnemyShoot", false);
                    //}

                }

                totalReloadTime += Time.deltaTime;
            }
            if (totalReloadTime > reloadTimesss)
            {
                ResetReloadTime(reloadWaitTime);
            }
        }
    }

    public bool GetDistance()
    {
        if (closestChicken != null)
        {
            bool _isRange = Vector3.Distance(transform.position, closestChicken.transform.position) <= attackRange;
            return _isRange;
        }
        return false;
    }

    public bool GetDistancePlayer()
    {
        if (player != null)
        {
            bool _range = Vector3.Distance(transform.position, player.transform.position) <= attackRange;
            return _range;
        }
        return false;
    }


    private async void ResetReloadTime(int time)
    {
        await System.Threading.Tasks.Task.Delay(1000 * time);
        totalReloadTime = 0f;
    }

    public Transform GetClosestChicken()
    {
        spawnedChickens = GameObject.FindGameObjectsWithTag("WarriorChicken");
        float closestChickenDistance = Mathf.Infinity;
        Transform trans = null;
        foreach (GameObject chicken in spawnedChickens)
        {
            try
            {
                float currentDistance;
                currentDistance = Vector3.Distance(transform.position, chicken.transform.position);
                if (currentDistance < closestChickenDistance)
                {
                    closestChickenDistance = currentDistance;
                    trans = chicken.transform;
                }
            }
            catch
            {

            }
        }
        return trans;
    }
}
