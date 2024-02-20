using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        foreach (var timer in Timer.timers)
        {
            timer.UpdateTimer(Time.deltaTime);
        }
    }
}
