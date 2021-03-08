using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI stuff")]
    public GameObject startButton;

    [Header("Position stuff")]
    public GameObject[] racers;

    public GameObject canvas;
    public GameObject events;


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

    //public IEnumerator updateRacerPos(GameObject[] r)
    //{
      //Coroutine here that checks the position of each racer and sorts them
      //in an array according to how close they are to the finish line or checkpoint
    //}


    //Coroutine or something that routinely checks the list of racers
    //and returns index+1 as the position of the player racer
    public int getRacerPos(string name)
    {
        int pos = 0;
        for(int i = 0; i < racers.Length; i++)
        {
            if(racers[i].name == name)
            {
                pos = i+1;
                break;
            }
        }
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
