using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float fireRate = 0;
    public float Damage = 0;
    public int ammo = 0;
    private int currentAmmo = 0;
    [SerializeField] private LayerMask notToHit;

    [SerializeField] private GameObject bullet;

    private float timeToFire = 0;
    private Transform endOfGun;

    private void Awake()
    {
        endOfGun = transform.Find("FirePoint");
        if (endOfGun == null)
        {
        }
        currentAmmo = ammo;
    }

    private void OnEnable()
    {
        currentAmmo = ammo;
    }

    private void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetMouseButton(0) && currentAmmo > 0)
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire && currentAmmo > 0)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(endOfGun.position.x, endOfGun.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, notToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

        GameObject bul = Instantiate(bullet, endOfGun.position, endOfGun.rotation);
        bul.GetComponent<bulletMove>().Damage = Damage;

        currentAmmo--;
    }
}