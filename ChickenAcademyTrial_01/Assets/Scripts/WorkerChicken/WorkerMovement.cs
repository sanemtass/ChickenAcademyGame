using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    public bool isTargetLocked=false;
    public float colliderRange=10f;
    public int collectLimit = 4;
    public int collectedWorms;
   
    private void LateUpdate()
    {
        Collider[] hitColliders= Physics.OverlapSphere(transform.position, colliderRange);
        foreach (var targets in hitColliders)
        {
            if (targets.gameObject.CompareTag("Worm"))
            {

            }
        }
    }
}
