using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Egg")
        {
            EggStackManager.instance.PickUp(other.gameObject, true, "Egg");
            
        }
    }
}
