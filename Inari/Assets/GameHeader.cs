using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHeader : MonoBehaviour
{
    public float timeRemaining = 10;
    public Narrator narrator;
    public int day;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining < 8 && day ==1)
        {
            day++;
            if (narrator != null)
            {
                narrator.play();
            }
            
        }
    }

    int getDay()
    {
        return day;
    }
        

}
