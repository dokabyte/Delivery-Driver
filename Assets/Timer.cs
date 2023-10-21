using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remaningTime;
    public bool timeStop = false;


    


    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            remaningTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remaningTime / 60);
            int seconds = Mathf.FloorToInt(remaningTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void PauseTime()
    {
        timeStop = true;
    }
}
