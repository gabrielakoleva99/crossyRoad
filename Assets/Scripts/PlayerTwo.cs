using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//same as player 1 but moves with different keyboard keys
public class PlayerTwo : MonoBehaviour
{

    private Animator animator;
    private bool isHopping;
    [SerializeField] private TerrainGenerator generator;
    [SerializeField] private Text scoreText;

    public int score = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        scoreText.text = "Score Player 2: 0";

        score = 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            float zDifference = 0;
            score += 1;
            scoreText.text = "Score Player 2: " + score;
            if (transform.position.z % 1 == 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            transform.position = (transform.position + new Vector3(1, 0, zDifference));
            generator.SpawnTerrain(false, transform.position);

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = (transform.position + new Vector3(0, 0, 1));
            generator.SpawnTerrain(false, transform.position);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = (transform.position + new Vector3(0, 0, -1));
            generator.SpawnTerrain(false, transform.position);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Log>() != null)
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
