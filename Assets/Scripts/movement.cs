using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody body;
    private float horizontal, vertical;

    public float speed, turnSpeed, maxSpeed, maxTurnSpeed, maxBackwardSpeed;
    private float stunTime = 2, bumperForce = 15;
    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = maxTurnSpeed;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (startTimer && stunTime > 0)
        {
            stunTime -= Time.deltaTime;
            horizontal = 0;
        }
        else if (stunTime < 0)
        {
            startTimer = false;
            stunTime = 2;
            Debug.Log("not stung");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (vertical == 1 && body.velocity.magnitude < maxSpeed)
        {
            body.AddRelativeForce(Vector3.forward * speed);
            if (horizontal != 0)
            {
                body.AddRelativeTorque(horizontal * (Vector3.up * turnSpeed));
            }
        }
        if ((vertical == -1 || Input.GetKey(KeyCode.Space)) && body.velocity.magnitude < maxBackwardSpeed)
        {
            body.AddRelativeForce(Vector3.back * speed);
            if (horizontal != 0)
            {
                body.AddRelativeTorque(horizontal * (Vector3.up * turnSpeed));
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Boost":
                Debug.Log("boosting");
                body.AddRelativeForce(Vector3.forward * 300);
                break;
            case "Slow":
                Debug.Log("slowed");
                maxSpeed = maxSpeed / 2;
                speed = speed / 2;
                break;
            case "Bumper":
                Debug.Log("bumped");
                body.velocity = Vector3.zero;
                Vector3 closestPoint = col.ClosestPointOnBounds(body.transform.position);
                body.AddExplosionForce(bumperForce, col.transform.position, 3, 0, ForceMode.Impulse);
                break;
            case "Jellyfish":
                Debug.Log("stung");
                startTimer = true;
                break;
            case "FinishLine":
                Debug.Log("finished");
                GetComponent<movement>().enabled = false;
                break;
            case "Checkpoint":
                Debug.Log("checkpoint");
                GetComponent<positionTracker>().newFinish();
                break;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Slow":
                Debug.Log("not slowed");
                maxSpeed = maxSpeed * 2;
                speed = speed * 2;
                break;
        }
    }
}
