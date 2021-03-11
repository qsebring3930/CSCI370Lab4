using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothing, rotSmoothing;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rotSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));
    }
}
