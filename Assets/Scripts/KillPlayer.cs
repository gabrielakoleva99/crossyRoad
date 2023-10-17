using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script kills player on collision
public class KillPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        } if(collision.collider.GetComponent<PlayerTwo>() != null)
        {
            Destroy(collision.gameObject);
        } else if(collision.collider.GetComponent<Player>() == null && collision.collider.GetComponent<PlayerTwo>() == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
