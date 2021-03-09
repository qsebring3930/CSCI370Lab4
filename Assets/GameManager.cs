using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI stuff")]
    public GameObject startButton, canvas, events;

    [Header("Position stuff")]
    public GameObject[] racers;
    public Transform line;


    private int playerpos = 0;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Coroutine here that checks the position of each racer and sorts them
    //in an array according to how close they are to the finish line or checkpoint
    public IEnumerator updateRacerPos(GameObject[] r)
    {
        Vector3 localPos;
        for(int i = 0; i <= r.Length; i++)
        {
            localPos = r[i].transform.position - line.position;
            for(int j = 0; j <= r.Length; j++)
            {
                if(racers[j] == null)
                {
                    racers[j] = r[i];
                    break;
                }
            }
        }

    }


    //Coroutine or something that routinely checks the list of racers
    //and returns index+1 as the position of the player racer
    public IEnumerator getRacerPos(string name)
    {
        for(int i = 0; i <= racers.Length; i++)
        {
            if(racers[i].name == name)
            {
                yield return playerpos = i+1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
