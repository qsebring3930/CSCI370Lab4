using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMove : MonoBehaviour
{
    public Transform[] checkpoints;
    public GameObject player;
    public int i;
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
        this.agent.SetDestination(checkpoints[i].position);
    }

    // Update is called once per frame
    void Update()
    {
        onYourRight = Physics.Raycast(transform.position, Vector3.right, sight, layer);
        onYourLeft = Physics.Raycast(transform.position, Vector3.left, sight, layer);
    }

    private void FixedUpdate()
    {
        if (onYourRight)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * sight, Color.yellow);
        }
        if (onYourLeft)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * sight, Color.yellow);
        }
        rb.velocity = agent.velocity;
        agent.nextPosition = rb.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Checkpoint":
                if (i < checkpoints.Length - 1)
                {
                    i++;
                    this.agent.SetDestination(checkpoints[i].position);
                } else
                {
                    i = 0;
                    this.agent.SetDestination(checkpoints[i].position);
                    player.GetComponent<positionTracker>().aiLap();
                }
                break;
        }

    }
}
