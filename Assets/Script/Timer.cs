using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 0;
    public Text timerText;

    private void Update()
    {
        timeValue += Time.deltaTime;
        DisplayTime(timeValue); 
    }

    void DisplayTime(float TimeToDisplay)
    {
        if(TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(TimeToDisplay/60);
        float seconds = Mathf.FloorToInt(TimeToDisplay%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
