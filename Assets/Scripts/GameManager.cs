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
        float a = 0.0f;
        float b = 0.0f;
        GameObject temp;
        for(int i = 1; i < r.Length; i++)
        {
            for(int j = i-1; j >= 0; j--)
            {
                a = Vector3.Distance(r[j + 1].transform.position, line.position);
                b = Vector3.Distance(r[j].transform.position, line.position);
                if (a < b)
                {
                    temp = r[j];
                    r[j] = r[j + 1];
                    r[j + 1] = temp;
                }
            }
        }

    }


    //Coroutine or something that routinely checks the list of racers
    //and returns index+1 as the position of the player racer
    public void getRacerPos(GameObject[] r, string name)
    {
        positionTrack.GetComponent<TextMeshProUGUI>().text = "Pos:";
        for(int i = 0; i <= r.Length; i++)
        {
            if(r[i].name == name)
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
