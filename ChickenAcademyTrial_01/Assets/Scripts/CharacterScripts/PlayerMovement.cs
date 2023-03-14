using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public Joystick joystick;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public static float speed=350f;
    int speedParameter;
    Vector3 movementVector;
    public float rotateSpeed = 10f;

    private bool _isMoving;

    public GameObject district_1;
    public GameObject district_2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
        speedParameter = UIManager.Instance.playerSpeedParameter;
        Debug.Log(speed + "first");
        horizontalMove = joystick.Horizontal * speed * Time.deltaTime;
        verticalMove = joystick.Vertical * speed * Time.deltaTime;
        movementVector = new Vector3(horizontalMove, 0, verticalMove);
        movementVector = movementVector.normalized;
        Debug.Log(speed + "second");
        //transform.Translate(movementVector);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("isMoving", true);
            Vector3 direction = Vector3.RotateTowards(transform.forward, movementVector, rotateSpeed * Time.deltaTime, 0.0f);
            direction = direction.normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            anim.SetBool("isMoving", false);
        }
        rb.MovePosition(rb.position + movementVector * Time.deltaTime * speedParameter);

    }
    private void FixedUpdate()
    {
        if (transform.position.x < district_1.transform.position.x)
        {
            transform.position = new Vector3(district_1.transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > district_2.transform.position.x)
        {
            transform.position = new Vector3(district_2.transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z < district_1.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, district_1.transform.position.z);
        }
        if (transform.position.z > district_2.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, district_2.transform.position.z);
        }
    }
    public bool IsMoving()
    {
        return _isMoving;
    }
}
