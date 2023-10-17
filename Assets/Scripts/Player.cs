using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Player script defines players moves and tracks score when moved
public class Player : MonoBehaviour
{

    private Animator animator;
    private bool isHopping;
    [SerializeField] private TerrainGenerator generator;
    [SerializeField] private Text scoreText;

    public int score = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        score = 0;
        scoreText.text = "Score Player 1: 0";
    }

    /*private void FixedUpdate()  
    {
        score++;
    }*/

    // transform position taken from youtube tutorial
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            score += 1;
            scoreText.text = "Score Player 1: " + score;
            float zDifference = 0;
            if(transform.position.z % 1 == 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            transform.position = (transform.position + new Vector3(1, 0, zDifference));
            generator.SpawnTerrain(false, transform.position);

        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = (transform.position + new Vector3(0, 0, 1));
            generator.SpawnTerrain(false, transform.position);

        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = (transform.position + new Vector3(0, 0, -1));
            generator.SpawnTerrain(false, transform.position);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Log>() != null)
        {
            if (collision.collider.GetComponent<Log>())
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    public void FInishHopp()
    {
        isHopping = false;
    }

 
}
