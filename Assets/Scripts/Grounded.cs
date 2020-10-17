using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private GameObject Player;
    private int grndCheck = 0;

    private void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grndCheck++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grndCheck--;
        }
    }

    private void Update()
    {
        if (grndCheck > 0)
            Player.GetComponent<PlayerController>().isGrounded = true;
        else
            Player.GetComponent<PlayerController>().isGrounded = false;
    }
}