using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWormCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mother"))
        {
            gameObject.transform.parent.transform.parent = GameObject.Find("ObjectPoolingManager").gameObject.transform.Find("_FakeWorm (UnityEngine.GameObject)").gameObject.transform;
            ObjectPooling.Instance.SetPoolObject(gameObject,4);
        }
    }
}
