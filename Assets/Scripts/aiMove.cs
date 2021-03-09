using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMove : MonoBehaviour
{
    [SerializeField]public Transform goal;
    private NavMeshAgent agent;
    private Rigidbody rb;

    [Header("Steering")]
    public float sight;
    public LayerMask layer;
    private bool onYourRight, onYourLeft;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        onYourRight = Physics.Raycast(transform.position, Vector3.right, sight, layer);
        onYourLeft = Physics.Raycast(transform.position, Vector3.left, sight, layer);
        agent.SetDestination(goal.position);
    }

    private void FixedUpdate()
    {
        if (onYourRight)
        {
            Debug.Log("On your right!");
        }
        if (onYourLeft)
        {
            Debug.Log("On your left!");
        }
        rb.velocity = agent.velocity;
        agent.nextPosition = rb.position;
    }
}
