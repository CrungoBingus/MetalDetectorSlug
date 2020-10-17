using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float moveSpeed = 0;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}