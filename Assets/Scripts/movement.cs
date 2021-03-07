using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody body;
    private float horizontal, vertical;

    public float forAccel, backAccel, speed, maxSpeed, turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))
        {
            body.AddRelativeForce(vertical*(Vector3.forward*speed));
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                body.AddTorque(horizontal * (Vector3.up * turnSpeed));
            }
        }
        
    }
}
