using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marblefollow : MonoBehaviour
{
    public GameObject objectOfAttraction;
    public float attractionStrength,radius,distance;
    public bool giveUp;

    Transform myTransform;
    Rigidbody myRigidbody;

    void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (giveUp)
        {
            cheatMovement();
        }
        else
        {
            // get the positions of this object and the target
            Vector3 targetPosition = objectOfAttraction.transform.position;
            Vector3 myPosition = myTransform.position;

            // work out direction and distance
            Vector3 direction = (targetPosition - myPosition).normalized;
            distance = Vector3.Magnitude(targetPosition - myPosition);       // you could move this inside the switch to avoid processing it for the Constant case where it's not used

            Vector3 resultingForceAmount = Vector3.zero;
            // depending on which type of attraction, work out the appropriate
            // amount and direction of force to apply to cause movemen
            if (distance < radius)
            {
                resultingForceAmount = attractionStrength * direction * (distance / radius);
            }
            else
            {
                resultingForceAmount = attractionStrength * direction;
            }
            if (objectOfAttraction.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                myRigidbody.velocity = Vector3.zero;
                myRigidbody.angularVelocity = Vector3.zero;
            }
            myRigidbody.AddForce(resultingForceAmount);
        }
    }

    void cheatMovement()
    {
        transform.position = objectOfAttraction.transform.position;
    }
}
