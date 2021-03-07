using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMove : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        //agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(goal.position);
    }

    private void FixedUpdate()
    {
        rb.velocity = agent.velocity;
        agent.nextPosition = rb.position;
    }
}
