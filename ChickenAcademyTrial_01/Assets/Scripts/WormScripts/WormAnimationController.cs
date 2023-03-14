using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAnimationController : MonoBehaviour
{
    public Animator anim;
   
  public  void Start()
    {
        anim = GetComponent<Animator>();       
    }

    public void Attack()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);
        Debug.Log("Attack Else");
        anim.SetBool("Attack1",true);
    }

}
