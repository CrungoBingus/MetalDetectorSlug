using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeSinceShoot = 0f;

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

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceShoot += Time.deltaTime;
        if (timeSinceShoot >= FireRate)
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
}