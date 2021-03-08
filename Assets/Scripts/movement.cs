using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody body;
    private float horizontal, vertical;

    public float speed, turnSpeed, maxSpeed, maxTurnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = maxTurnSpeed;
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0 && body.velocity.magnitude < maxSpeed)
        {
            body.AddRelativeForce(vertical * (Vector3.forward*speed));
        }
        if (horizontal != 0)
        {
            body.AddRelativeTorque(horizontal * (transform.up * turnSpeed));
        }
    }
}
