using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Score playerScoreOnDeath;
    public bool isGrounded = false;

    public Animator animator;

    private void Update()
    {
        //Player X Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        animator.SetFloat("Movement", Input.GetAxis("Horizontal"));
        animator.SetFloat("UpDownie", gameObject.GetComponent<Rigidbody2D>().velocity.y);
        animator.SetBool("Grounded", isGrounded);

        //Jump Check
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            playerScoreOnDeath = GameObject.FindGameObjectWithTag("WorldHandle").GetComponent<Score>();
            PlayerPrefs.SetInt("LastRunsScore", playerScoreOnDeath.score);
            SceneManager.LoadScene(2);
        }
    }
}