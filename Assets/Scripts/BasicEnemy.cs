using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeSinceShoot = 0f;

    [SerializeField] private Transform shootPos;
    private Quaternion shootRot;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float health = 50;

    [SerializeField] private float FireRate = 1.5f;

    private float hold = 0f;

    //Damage popup stuff
    [SerializeField] private Transform pfDamagePopup;

    private Transform damagePopupTransform;
    private DamagePopup damagePopup;

    [SerializeField] private Transform target;
    [SerializeField] private Score scoreUp;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        scoreUp = GameObject.FindGameObjectWithTag("WorldHandle").GetComponent<Score>();
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceShoot += Time.deltaTime;
        if (timeSinceShoot >= (FireRate - (scoreUp.score / 1000)) && shootPos.position.x - target.position.x < 30)
        {
            shootPos.LookAt(target);
            timeSinceShoot = 0f;
            Instantiate(bullet, shootPos.position, shootPos.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hold = collision.gameObject.GetComponent<bulletMove>().Damage;
        damagePopupTransform = Instantiate(pfDamagePopup, this.transform.position, Quaternion.identity);
        damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(hold.ToString());
        health -= hold;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        scoreUp.score += Random.Range(7, 11);
    }
}