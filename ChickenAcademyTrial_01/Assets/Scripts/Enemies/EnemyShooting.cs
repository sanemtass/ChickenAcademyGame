using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Queue<GameObject> Bulletq = new Queue<GameObject>();
    public Vector3 Target;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.7)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        var Bullet = ObjectPooling.Instance.GetPoolObject(7);
        //tasin pozisyonu verilmemis
        //Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Bulletq.Enqueue(Bullet);
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1.7f);
        var Bullet = Bulletq.Dequeue();
        ObjectPooling.Instance.SetPoolObject(Bullet, 7);
    }
}
