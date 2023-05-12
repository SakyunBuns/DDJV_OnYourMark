using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class levelManager : MonoBehaviour
{
    private UnityAction<object> ev_redDeath;
    private UnityAction<object> ev_greenDeath;
    private UnityAction<object> ev_playerVictory;
    
    private int currentLvlIdx;
    private bool isRedAlive;
    private bool isGreenAlive;


    // Start is called before the first frame update
    void Start()
    {
        isRedAlive = true;
        isGreenAlive = true;
        currentLvlIdx = SceneManager.GetActiveScene().buildIndex;

        ev_redDeath = new UnityAction<object>(redRestartLevel);
        ev_greenDeath = new UnityAction<object>(greenRestartLevel);
        ev_playerVictory = new UnityAction<object>(loadNextLevel);

        EventManager.StartListening("PlayerReachedObjective", ev_playerVictory);
        EventManager.StartListening("RedBeenHit", ev_redDeath);
        EventManager.StartListening("GreenBeenHit", ev_greenDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void redRestartLevel(object someObject) {
        isRedAlive = false;
        if (!isGreenAlive) {
            SceneManager.LoadScene(currentLvlIdx);
        }
    }

    void greenRestartLevel(object someObject) {
        isGreenAlive = false;
        if (!isRedAlive) {
            SceneManager.LoadScene(currentLvlIdx);
        }
    }

    void loadNextLevel(object someObject) {
        SceneManager.LoadScene(currentLvlIdx + 1);
    }
}
