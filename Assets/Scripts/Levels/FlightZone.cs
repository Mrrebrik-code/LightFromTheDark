using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().OnEndBallonMove();
        }
    }
}
