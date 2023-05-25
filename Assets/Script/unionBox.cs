using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unionBox : MonoBehaviour
{

    private bool redInBox = false;
    private bool greenInBox = false;

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerGreen")
        {
            greenInBox = true;
        }

        if (collision.gameObject.tag == "PlayerRed")
        {
            redInBox = true;
        }

        if (redInBox && greenInBox)
        {
            BothPlayerInBox();
        }
        print("here " + redInBox + " " + greenInBox);
    }

    void BothPlayerInBox() {
        Destroy(gameObject);
    }
}
