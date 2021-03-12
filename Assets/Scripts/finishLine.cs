using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{
    // Start is called before the first frame update

    public int pos;
    public int lap = 1;

    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (lap == 3)
        {
            pos = gameManager.getPos();
            if (pos == 1)
            {
                gameManager.setScore(10);
            }
            else if (pos == 2)
            {
                gameManager.setScore(8);
            }
            else if (pos == 3)
            {
                gameManager.setScore(6);
            }
            else if (pos == 4)
            {
                gameManager.setScore(4);
            }
            else if (pos == 5)
            {
                gameManager.setScore(2);
            }
            else
            {
                gameManager.setScore(0);
            }
        }
        lap += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
