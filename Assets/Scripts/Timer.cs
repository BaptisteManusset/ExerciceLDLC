using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [SerializeField, Tooltip("Time in second")] private float timer = 30;

    public static UnityAction CountDownIsFinish;


    [SerializeField] private TMP_Text timerText;


    void Update() {
        if (timer <= 0) {
            CountDownIsFinish?.Invoke();
            timer = 0;
            enabled = false;
        }
        else {
            timer -= Time.deltaTime;
        }

        DisplayTimer();
    }

    private void DisplayTimer() {
        timerText.text = FormatTime(timer);
    }


    private static string FormatTime(float time) {
        TimeSpan t = TimeSpan.FromSeconds(time);
        return $"{t.Minutes,1:0}:{t.Seconds,2:00}";
    }
}