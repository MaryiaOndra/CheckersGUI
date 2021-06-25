using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CheckersGUi
{
    public class ChipTimer : MonoBehaviour
    {
        const float START_TIME = 300f;

        TMP_Text timerText;
        float secondTillUnlock;
        bool timerisOn;

        public Action FinishTimeAction;

        private void OnEnable()
        {
            timerText = GetComponentInChildren<TMP_Text>(true);
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
            var _key = PrefsKeys.Time_ + _chipIndx;
            var _timeLeft = PrefsKeys.TimeLeft + _chipIndx;
            long currenttime = DateTime.UtcNow.Ticks;

            AppPrefs.SetString(_key, currenttime.ToString());
            AppPrefs.SetFloat(_timeLeft, secondTillUnlock);

            timerisOn = false;
        }

        public void GetStartTime(int _chipIndx)
        {
            var _key = PrefsKeys.Time_ + _chipIndx;
            var _timeLeft = PrefsKeys.TimeLeft + _chipIndx;

            if (!AppPrefs.HasKey(_key))
            {
                secondTillUnlock = START_TIME;
            }
            else
            {
                long currenttime = DateTime.UtcNow.Ticks;
                long savedTime = long.Parse(PlayerPrefs.GetString(_key, currenttime.ToString()));
                TimeSpan timeSpan = DateTime.UtcNow - new DateTime(savedTime);
                secondTillUnlock = AppPrefs.GetFloat(_timeLeft);
                secondTillUnlock -= (float)timeSpan.TotalSeconds;
            }
        }
    }
}
