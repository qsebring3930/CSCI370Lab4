using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionTracker : MonoBehaviour
{
    public GameObject[] racers;
    public string n = "Player";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.updateRacerPos(racers);
        GameManager.Instance.getRacerPos(n);
    }
}
