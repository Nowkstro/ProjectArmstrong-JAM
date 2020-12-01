using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{/*
    [SerializeField] private float duration = 1f;
    public float Duration { get => duration; set => duration = value; }*/

    public void AwaitForSeconds(float duration, Action onTimerEnd) {
        StartCoroutine(StartTimer(duration, onTimerEnd));
    }

    private IEnumerator StartTimer(float duration, Action onTimerEnd)
    {
        yield return new WaitForSeconds(duration);
        onTimerEnd?.Invoke();
    }

    public void StopTimer()
    {
        /*onTimerEnd?.Invoke();*/
        StopAllCoroutines();
    }
}