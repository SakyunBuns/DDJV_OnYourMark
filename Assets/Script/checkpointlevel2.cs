using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class checkpointlevel2 : MonoBehaviour
{
    private UnityAction<object> ev_checkPointRed;
    private UnityAction<object> ev_checkPointGreen;
    private bool redCheck = false;
    private bool greenCheck = false;


    void Start()
    {
        ev_checkPointRed = new UnityAction<object>(CheckPointRed);
        ev_checkPointGreen = new UnityAction<object>(CheckPointGreen);
        EventManager.StartListening("redKeyCollected", ev_checkPointRed);
        EventManager.StartListening("greenKeyCollected", ev_checkPointGreen);
    }

    private void CheckPointRed(object obj)
    {
        redCheck = true;
        if (redCheck && greenCheck)
        {
            Destroy(gameObject);
        }
    }

    private void CheckPointGreen(object obj)
    {
        greenCheck = true;
        if (redCheck && greenCheck)
        {
            Destroy(gameObject);
        }
    }
}
