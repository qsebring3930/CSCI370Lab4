using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothing, rotSmoothing;
    private Vector3 offset;
    private float newXPosition;
    private float newZPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rotSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));
    }
}
