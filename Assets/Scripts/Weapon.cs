using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource shootSound;
    private AudioSource clipSound;

    [SerializeField] private float fireRate = 0;
    [SerializeField] private float bulletSpeed = 0;

    [SerializeField] private int numberOfProjectiles = 1;

    public int MinDamage = 0;
    public int MaxDamage = 0;
    public int ammo = 0;
    public int currentAmmo = 0;
    [SerializeField] private LayerMask notToHit;
    [SerializeField] private GameObject muzzleFlash;

    [SerializeField] private GameObject bullet;

    [SerializeField] private UiController UICont;

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

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        shootSound = sounds[0];
        clipSound = sounds[1];
    }

    private void OnEnable()
    {
        currentAmmo = ammo;
        UICont.UpdateAmmo(currentAmmo);
    }

    private void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetMouseButton(0) && currentAmmo > 0)
            {
                Shoot(numberOfProjectiles);
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire && currentAmmo > 0)
            {
                timeToFire = Time.time + 1 / fireRate;
                int hold = numberOfProjectiles;
                if (hold > 1)
                    hold = numberOfProjectiles + Random.Range(-2, 2);
                if (hold > 0)
                    Shoot(hold);
                else clipSound.Play();
            }
            else if (Input.GetMouseButton(0) && Time.time > timeToFire && currentAmmo == 0)
            {
                clipSound.Play();
                timeToFire = Time.time + 1 / fireRate;
                clipSound.Play();
            }
        }
    }

    private void Shoot(int projCount)
    {
        MuzzleFlash();
        shootSound.Play();
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(endOfGun.position.x, endOfGun.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, notToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

        for (int i = 0; i < projCount; i++)
        {
            GameObject bul = Instantiate(bullet, endOfGun.position,
                endOfGun.rotation);
            bul.GetComponent<bulletMove>().Damage = Random.Range(MaxDamage, MinDamage);
            bul.GetComponent<bulletMove>().moveSpeed = bulletSpeed;
        }
        currentAmmo--;
        UICont.UpdateAmmo(currentAmmo);
    }

    private void MuzzleFlash()
    {
        GameObject clone = Instantiate(muzzleFlash, endOfGun.position,
            Quaternion.Euler(endOfGun.rotation.x + Random.Range(-5f, 5f), endOfGun.rotation.y, endOfGun.rotation.z));
        float size = Random.Range(0.6f, 0.9f);
        clone.transform.parent = endOfGun;
        Destroy(clone, 0.1f);
    }
}