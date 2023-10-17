using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script kills player on collision with car
public class CarKillsPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
    }
}
