using System;
using TMPro;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text text_timer;

    private TimeSpan timer = TimeSpan.Zero;

    private bool isRunning = true;

    private void Update()
    {
        if (!isRunning)
            return;

        timer += TimeSpan.FromSeconds(Time.deltaTime);
        text_timer.text = timer.ToString(@"hh\:mm\:ss");
    }
}
