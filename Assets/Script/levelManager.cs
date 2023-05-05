using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class levelManager : MonoBehaviour
{
    private UnityAction<object> ev_playerDeath;
    private UnityAction<object> ev_playerVictory;
    
    private int currentLvlIdx;


    // Start is called before the first frame update
    void Start()
    {
        currentLvlIdx = SceneManager.GetActiveScene().buildIndex;

        ev_playerDeath = new UnityAction<object>(restartLevel);
        ev_playerVictory = new UnityAction<object>(loadNextLevel);

        EventManager.StartListening("PlayerReachedObjective", ev_playerVictory);
        EventManager.StartListening("PlayerBeenHit", ev_playerDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restartLevel(object someObject) {
        SceneManager.LoadScene(currentLvlIdx);

    }

    void loadNextLevel(object someObject) {
        SceneManager.LoadScene(currentLvlIdx + 1);
    }
}
