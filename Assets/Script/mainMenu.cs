using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField]
    private Transform m_menuconfirm;

    public void OnPause()
    {

        // Pauser le son
        // Desactiver les controles
        if (Time.timeScale > 0.5f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTryQuit()
    {
        m_menuconfirm.transform.gameObject.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.LogWarning("Application devrait etre fermer");
    }

    public void OnCancelQuit()
    {
        m_menuconfirm.transform.gameObject.SetActive(false);
    }
}
