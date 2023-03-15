using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGroup : MonoBehaviour
{
    private GameObject target;

    private float onRange = 12f;

    private void LateUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, onRange);

        foreach (var item in hitColliders)
        {
            if (item.gameObject.CompareTag("WarriorChicken")||item.gameObject.CompareTag("Player"))
            {
                target = item.gameObject;
                foreach (Transform childObject in this.transform)
                {
                    Animator anim = childObject.GetComponent<Animator>();
                    Debug.Log("RRRR");
                    anim.SetBool("EnemyShoot", true);
                    childObject.transform.LookAt(item.transform.position);
                    childObject.GetComponent<AIPath>().slowdownDistance = 3;
                    childObject.GetComponent<AIPath>().endReachedDistance = 5;
                }
            }
            else
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, onRange);
    }
}
