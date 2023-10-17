using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script follows the two players
public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> players;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;
    // if both players are alive camera follows the middle of the distance between them
    //otherwise it follow the player left
    void Update()
    {
        if (players.Count > 1)
        {
            Vector3 middle = Vector3.zero;
            foreach (GameObject player in players)
            {
                if (player != null) {
                    middle += player.transform.position;
                    middle /= players.Count;

                    transform.position = Vector3.Lerp(transform.position, middle + offset, smoothness);
                }
            }
          
        }
   
    }

    // Add a player to the list of players to follow
    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    // Remove a player from the list of players to follow
    public void RemovePlayer(GameObject player)
    {
        players.Remove(player);
    }

}
