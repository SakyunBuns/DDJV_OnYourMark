using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GreenDoor : MonoBehaviour
{
    [SerializeField]
    private int m_keyTag;
    private UnityAction<object> ev_keyCollected;
    
    [SerializeField]
    private Transform sparkleVFX;

    void Start()
    {
        ev_keyCollected = new UnityAction<object>(GreenKeyCollected);

        EventManager.StartListening("greenKeyCollected", ev_keyCollected);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GreenKeyCollected(object keyNumber)
    {
        if ((int)keyNumber == m_keyTag)
        {
            StartCoroutine(DestroyFX());
        }
    }

    IEnumerator DestroyFX()
    {
        Instantiate(sparkleVFX, transform.position + Vector3.down, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }
}
