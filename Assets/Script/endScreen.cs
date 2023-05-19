using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{

    [SerializeField]
    private float limitX = 10;
    private float limitY = 5;
    private Transform[] list;

    [SerializeField]
    private Transform wowFX;
    [SerializeField]
    private Transform secondFX;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {

        for (int nb_fx = 0; nb_fx < 15; nb_fx++)
        {
            int idxVFX = Random.Range(0, 2);

            Vector3 randVect3 = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY), 0);
            Instantiate(wowFX, transform.position + randVect3, transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
