using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChipTimer : MonoBehaviour
{
    const float START_TIME = 10.3f;

    TMP_Text timerText;
    float secondTillUnlock;
    bool timerisOn;

    public Action FinishTimeAction;

    private void OnEnable()
    {
        timerText = GetComponentInChildren<TMP_Text>(true);


        //secondTillUnlock = GetTime();
    }

    private void OnDisable()
    {
        
    }

    public void StartTimer()
    {
        timerisOn = true;
    }

    private void Update()
    {
        if (timerisOn)
        {
            secondTillUnlock -= Time.deltaTime;
            DisplayTime(secondTillUnlock);

            if (secondTillUnlock <= 0)
            {
                FinishTimeAction.Invoke();
                Destroy(gameObject);
            }
        }
    }

    void DisplayTime(float _timeToDisplay)
    {
        _timeToDisplay -= 1;

        float minutes = Mathf.FloorToInt(_timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(_timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTime(int _chipIndx) 
    {
        AppPrefs.SetString(PrefsKeys.Time_ + _chipIndx, DateTime.Now.ToShortTimeString());
    }

    public void GetStartTime(int _chipIndx) 
    {
        string _timeString = AppPrefs.GetString(PrefsKeys.Time_ + _chipIndx);

        if (_timeString == string.Empty)
        {
            secondTillUnlock = START_TIME;
        }
        else
        {
            var _time = DateTime.Parse(_timeString) - DateTime.Now;
            var _seconds = _time.TotalSeconds;
            secondTillUnlock = (float)_seconds;
        }

        Debug.Log("secondTillUnlock   :" + secondTillUnlock);
    }
}
