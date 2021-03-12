using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{
    // Start is called before the first frame update

    public int pos;

    void Start()
    {
        pos = GameManager.getPos();
        if (pos == 1)
        {
            GameManager.setScore(10);
        } else if (pos == 2)
        {
            GameManager.setScore(8);
        } else if (pos == 3)
        {
            GameManager.setScore(6);
        }
        else if (pos == 4)
        {
            GameManager.setScore(4);
        }
        else if (pos == 5)
        {
            GameManager.setScore(2);
        }
        StartCoroutine(GameManager.LoadAnAsyncScene("Level 2"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
