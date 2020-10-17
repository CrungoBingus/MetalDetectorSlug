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

    private float hold = 0f;

    //Damage popup stuff
    [SerializeField] private Transform pfDamagePopup;

    private Transform damagePopupTransform;
    private DamagePopup damagePopup;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceShoot += Time.deltaTime;
        if (timeSinceShoot >= 1.5f)
        {
            timeSinceShoot = 0f;
            shootRot = Quaternion.Euler(0f, 0f, Random.Range(180f, 130f));
            Instantiate(bullet, shootPos.position, shootRot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hold = collision.gameObject.GetComponent<bulletMove>().Damage + (Random.Range(-5, 5));
        damagePopupTransform = Instantiate(pfDamagePopup, this.transform.position, Quaternion.identity);
        damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(hold.ToString());
        health -= hold;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hold = (collision.gameObject.GetComponent<bulletMove>().Damage * 2) + (Random.Range(-5, 5));
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