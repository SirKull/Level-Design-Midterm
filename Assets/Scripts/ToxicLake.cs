using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicLake : MonoBehaviour
{
    public Transform player;
    public Transform playerStartPosition;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = playerStartPosition.transform.position;
        }
    }
}
