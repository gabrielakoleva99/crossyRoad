using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// loads end scene when player dies
public class OnPlayerDeath : MonoBehaviour
{
 


    public Player p1;
    public PlayerTwo p2;
    public string name;

    private bool player1Alive = true;
    private bool player2Alive = true;

    private void Update()
    {
        if (!player1Alive && !player2Alive)
        {
            SceneManager.LoadScene(name);
        }
    }

    public void PlayerDie(Player player, PlayerTwo playerTwo)
    {
        if (player == p1)
        {
            player1Alive = false;
        }
        else if (playerTwo == p2)
        {
            player2Alive = false;
        }
    }
}


