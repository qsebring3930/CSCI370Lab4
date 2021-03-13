using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionTracker : MonoBehaviour
{
    public GameObject[] racers;
    public string n = "Player";
    public Transform[] checkpoints;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.updateRacerPos(racers, checkpoints[index]);
        GameManager.Instance.getRacerPos(racers, n);
    }

    public void newFinish()
    {
        if (index < 7)
        {
            index++;
        } else
        {
            index = 0;
        }
    }
}
