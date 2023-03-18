using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WormMovement : MonoBehaviour
{
    Animator anim;
    private bool _isPlayerLevelLower;
    private bool _isPlayerLevelHigher;

    [SerializeField]
    int wormLevel;
    public GameObject target;
    public float turnSpeed = 20.0f;
    float colliderRange = 7f;
    public GameObject wormChild;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, colliderRange);

        foreach (var targets in hitColliders)
        {
            if (targets.gameObject.CompareTag("Player"))
            {
                Debug.Log("entered");
                wormChild.transform.LookAt(targets.transform);
            }
        }

        if (anim)
        {
            anim.SetBool("PlayerLevelLower", _isPlayerLevelLower);
            anim.SetBool("PlayerLevelHigher", _isPlayerLevelHigher);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }
}