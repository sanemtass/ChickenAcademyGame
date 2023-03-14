using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormTriggerController : MonoBehaviour
{
    public GameObject mouth;
    float distance;
    public Animator animator;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = mouth.transform.position;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHead"))
        {
            distance = Vector3.Distance(body.transform.position,transform.position);
            Invoke("Eat", 0.5f);
            if (distance > 3)
            {
                Debug.Log("Girdi");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHead"))
        {
            distance = 0;
        }
    }
    public void Eat()
    {
        gameObject.transform.parent = mouth.transform;
    }
}
