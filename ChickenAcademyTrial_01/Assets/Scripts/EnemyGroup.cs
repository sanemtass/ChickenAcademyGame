using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGroup : MonoBehaviour
{
    private GameObject target;

    private float onRange = 12f;

    private void Start()
    {

    }

    private void LateUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, onRange);

        foreach (var item in hitColliders)
        {
            if (item.gameObject.CompareTag("WarriorChicken")||item.gameObject.CompareTag("Player"))
            {
                //yurume animasyonu
                //anim.SetBool("Walking", true);
                target = item.gameObject;
                foreach (Transform childObject in this.transform)
                {
                    Animator anim = childObject.GetComponent<Animator>();
                    Debug.Log("RRRR");
                    anim.SetBool("EnemyShoot", true);
                    //AIDestinationSetter setter = childObject.GetComponent<AIDestinationSetter>();
                    //setter.target = target.gameObject.transform;
                    childObject.transform.LookAt(item.transform.position);
                    childObject.GetComponent<AIPath>().slowdownDistance = 3;
                    childObject.GetComponent<AIPath>().endReachedDistance = 5;
                    //anim.SetBool("Walking", false);
                    //GunShoot gunshoot = childObject.GetComponent<GunShoot>();
                    //gunshoot.ShootShoot();
                    

                }
            }
            else
            {
                target = null;
                foreach (Transform childObject in this.transform)
                {
                    //AIDestinationSetter setter = childObject.GetComponent<AIDestinationSetter>();
                    //setter.target = childObject;
                    //Animator anim = childObject.GetComponent<Animator>();
                    //anim.SetBool("Walking", false);
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, onRange);
    }
}
