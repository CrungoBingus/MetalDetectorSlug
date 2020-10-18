using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject target;

    // public GameObject CurrentGameObject;

    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        Vector3 PathToTarget;

        PathToTarget = (target.transform.position - gameObject.GetComponent<Transform>().position).normalized;

        gameObject.GetComponent<Rigidbody2D>().AddForce(PathToTarget * speed * Time.deltaTime);
    }
}