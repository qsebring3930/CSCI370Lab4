using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionTracker : MonoBehaviour
{
    public GameObject[] racers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameManager.Instance.updateRacerPos(racers));
        StartCoroutine(GameManager.Instance.updatePosition("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
