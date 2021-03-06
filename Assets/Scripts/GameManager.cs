﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI stuff")]
    public GameObject startButton, creditButton, howTo, back, positionBox;
    public TextMeshProUGUI positionTrack;
    public GameObject canvas, title, events;
    public GameObject howToText, credits;
    public GameObject backgroundImage;
    public int position = 0;
    public int score = 0;

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
            DontDestroyOnLoad(creditButton);
            DontDestroyOnLoad(howTo);
            DontDestroyOnLoad(title);
            DontDestroyOnLoad(back);
            DontDestroyOnLoad(howToText);
            DontDestroyOnLoad(credits);
            DontDestroyOnLoad(backgroundImage);
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
        title.SetActive(false);
        creditButton.SetActive(false);
        howTo.SetActive(false);
        positionBox.SetActive(true);
        backgroundImage.SetActive(false);
        StartCoroutine(LoadAnAsyncScene("Level 1"));
    }

    public void loadCredits(GameObject n)
    {
        startButton.SetActive(false);
        title.SetActive(false);
        back.SetActive(true);
        creditButton.SetActive(false);
        howTo.SetActive(false);
        n.SetActive(true);
    }

    public void Back()
    {
        startButton.SetActive(true);
        title.SetActive(true);
        back.SetActive(false);
        creditButton.SetActive(true);
        howTo.SetActive(true);
        howToText.SetActive(false);
        credits.SetActive(false);
    }

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
                position = i + 1;
                break;
            }
        }
    }

    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LoadAnAsyncScene(string level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 2));
    }

    public void newScore()
    {
        if (position == 1)
        {
            setScore(10);
        } else if (position == 2)
        {
            setScore(8);
        } else if (position == 3)
        {
            setScore(6);
        } else if (position == 4)
        {
            setScore(4);
        } else if (position == 5)
        {
            setScore(2);
        } else
        {
            setScore(0);
        }
        Debug.Log("current score: " + score);
    }

    public void setScore(int scoreadd)
    {
        score += scoreadd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
