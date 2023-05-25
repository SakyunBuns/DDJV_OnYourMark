using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{
    private Vector3 m_position_initial; 


    // Start is called before the first frame update
    void Start()
    {
        m_position_initial = transform.position;
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        Vector3 randVect = Random.insideUnitSphere;
        transform.position = m_position_initial + randVect / 10;

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GameStart());
    }
}
