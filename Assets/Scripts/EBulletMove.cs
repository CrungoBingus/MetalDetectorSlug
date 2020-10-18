using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletMove : MonoBehaviour
{
    public float moveSpeed = 0;

    private void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}