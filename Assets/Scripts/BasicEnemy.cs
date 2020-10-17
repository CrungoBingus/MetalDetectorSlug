using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeSinceShoot=0f;
    Vector3 shootPos;
    Quaternion shootRot;

    [SerializeField] private GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShoot += Time.deltaTime;
        if(timeSinceShoot>=1.5f)
        {
            timeSinceShoot = 0f;
            shootPos= transform.position + new Vector3(-0.5f, 0f, 0f);
            shootRot = Quaternion.Euler(0f, 0f, Random.Range(180f, 130f));
            Instantiate(bullet, shootPos, shootRot);

        }
    }
}
