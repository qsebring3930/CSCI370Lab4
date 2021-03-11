using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI stuff")]
    public GameObject startButton, positionBox;
    public TextMeshProUGUI positionTrack;
    public GameObject canvas, events;

    [Header("Position stuff")]
    public GameObject[] racers;

    private int playerpos = 0;
    private Coroutine positionCo;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(positionBox);
            DontDestroyOnLoad(startButton);
            DontDestroyOnLoad(positionTrack);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    public void startGame()
    {
        startButton.SetActive(false);
        positionBox.SetActive(true);
        SceneManager.LoadScene(1);
    }

    //Coroutine here that checks the position of each racer and sorts them
    //in an array according to how close they are to the finish line or checkpoint
    public void updateRacerPos(GameObject[] r, Transform line)
    {
        float localPos = 0.0f;
        float temp = 0.0f;
        GameObject placeholder;
        for(int i = 0; i < r.Length; i++)
        {
            localPos = Vector3.Distance(r[i].transform.position, line.position);
            for(int j = 0; j < r.Length; j++)
            {
                if(racers[j] == null)
                {
                    racers[j] = r[i];
                    break;
                }
                temp = Vector3.Distance(racers[j].transform.position, line.position);
                if(temp > localPos)
                {
                    placeholder = racers[j];
                    racers[j] = r[i];
                    r[i] = placeholder;
                    continue;
                }
            }
        }

    }


    //Coroutine or something that routinely checks the list of racers
    //and returns index+1 as the position of the player racer
    public void getRacerPos(string name)
    {
        positionTrack.GetComponent<TextMeshProUGUI>().text = "Pos:";
        for(int i = 0; i <= racers.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(racers.Length);
            if(racers[i].name == name)
            {
                positionTrack.GetComponent<TextMeshProUGUI>().text = "Pos: " + (i+1);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
