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

    [SerializeField]
    private SpriteRenderer rendu;
    private float taux = 0.001f;


    // Start is called before the first frame update
    void Start()
    {
        isRedAlive = true;
        isGreenAlive = true;
        currentLvlIdx = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(Fondu());

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
        StartCoroutine(FonduFin());
    }

    IEnumerator Fondu()
    {
        Color alphaBuffer = Color.black;
        while (rendu.color.a > 0.5f)
        {
            alphaBuffer.a -= taux;
            rendu.color = alphaBuffer;
            yield return new WaitForEndOfFrame();
        }
        alphaBuffer.a = 0.0f;
        rendu.color = alphaBuffer;
    }

    public IEnumerator FonduFin()
    {
        Color alphaBuffer = Color.black;
        alphaBuffer.a = 0.0f;
        rendu.color = alphaBuffer;
        while (rendu.color.a < 0.5f)
        {
            alphaBuffer.a += taux;
            rendu.color = alphaBuffer;
            yield return new WaitForEndOfFrame();
        }
        alphaBuffer.a = 1.0f;
        rendu.color = alphaBuffer;
        SceneManager.LoadScene(currentLvlIdx + 1);
    }
}
