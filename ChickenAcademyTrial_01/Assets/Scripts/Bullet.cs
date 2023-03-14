using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * bulletSpeed);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Sakincali"))
    //    {
    //        ObjectPooling.Instance.SetPoolObject(gameObject, 4);
    //    }
    //}
}
