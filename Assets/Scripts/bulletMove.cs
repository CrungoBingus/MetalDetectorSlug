using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float moveSpeed = 0;
    public float Damage = 0;

    private float rng;

    private void Awake()
    {
        rng = Random.Range(-2.0f, 2.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * rng);
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}