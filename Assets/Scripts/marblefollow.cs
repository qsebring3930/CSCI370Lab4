using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marblefollow : MonoBehaviour
{
    public GameObject objectOfAttraction;
    public float attractionStrength;

    Transform myTransform;
    Rigidbody myRigidbody;

    void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // get the positions of this object and the target
        Vector3 targetPosition = objectOfAttraction.transform.position;
        Vector3 myPosition = myTransform.position; 

        // work out direction and distance
        Vector3 direction = (targetPosition - myPosition).normalized;

        Vector3 resultingForceAmount = Vector3.zero;

        resultingForceAmount = attractionStrength * direction;

        // then finally add the force to the rigidbody
        myRigidbody.AddForce(resultingForceAmount);

    }
}
