using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedDoor : MonoBehaviour
{
    [SerializeField]
    private int m_keyTag;
    private UnityAction<object> ev_keyCollected;
    
    [SerializeField]
    private Transform sparkleVFX;

    void Start()
    {
        ev_keyCollected = new UnityAction<object>(RedKeyCollected);

        EventManager.StartListening("redKeyCollected", ev_keyCollected);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RedKeyCollected(object keyNumber)
    {
        if ((int)keyNumber == m_keyTag)
        {
            StartCoroutine(DestroyFX());
        }
    }

    IEnumerator DestroyFX() {
        Instantiate(sparkleVFX, transform.position + Vector3.down, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }
}
