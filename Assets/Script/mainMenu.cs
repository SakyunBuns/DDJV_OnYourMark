using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField]
    private Transform m_menuconfirm;

    [SerializeField]
    private Transform m_labelTitle;

    [SerializeField]
    private Transform m_sparkleVFX;

    private void Start()
    {
        StartCoroutine(TitleEntrance());
    }

    private void FixedUpdate()
    {
        if (m_labelTitle.transform.position.y > 395)
        {
            m_labelTitle.transform.position = m_labelTitle.position - new Vector3(0, 1.0f);
        }
    }

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

    private IEnumerator TitleEntrance() {
        yield return new WaitForSeconds(0.5f);
        print(m_labelTitle.transform.position.y);
         
    }
}
