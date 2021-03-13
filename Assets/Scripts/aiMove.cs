using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMove : MonoBehaviour
{
    public Transform[] checkpoints;
    private int i;
    private NavMeshAgent agent;
    private Rigidbody rb;

    [Header("Steering")]
    public float sight;
    public LayerMask layer;
    private bool onYourRight, onYourLeft;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.SetDestination(checkpoints[0].position);

    }

    // Update is called once per frame
    void Update()
    {
        onYourRight = Physics.Raycast(transform.position, Vector3.right, sight, layer);
        onYourLeft = Physics.Raycast(transform.position, Vector3.left, sight, layer);
        if (i < checkpoints.Length)
        {
            if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                Debug.Log("YOU REACHED IT");
                i++;
                Debug.Log(i);
                this.agent.SetDestination(checkpoints[i].position);
            }
        }
    }

    private void FixedUpdate()
    {
        if (onYourRight)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * sight, Color.yellow);
            Debug.Log("On your right!");
        }
        if (onYourLeft)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * sight, Color.yellow);
            Debug.Log("On your left!");
        }
        rb.velocity = agent.velocity;
        agent.nextPosition = rb.position;
    }
    
}
