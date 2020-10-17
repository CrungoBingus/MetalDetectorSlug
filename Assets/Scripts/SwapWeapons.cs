using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class SwapWeapons : MonoBehaviour
{
    [SerializeField] private GameObject pistol, sniper, rifle;
    private int weapongSelected = 1;
    private int hold = 1;

    private void Start()
    {
        SwitchWeapon(weapongSelected);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            while (hold == weapongSelected)
            {
                hold = Random.Range(1, 4);
            }
            SwitchWeapon(hold);
            weapongSelected = hold;
        }
    }

    private void SwitchWeapon(int holder)
    {
        if (holder == 1)
        { //pistol
            pistol.SetActive(true);
            sniper.SetActive(false);
            rifle.SetActive(false);
        }
        if (holder == 2)
        { //sniper
            pistol.SetActive(false);
            sniper.SetActive(true);
            rifle.SetActive(false);
        }
        if (holder == 3)
        { //sniper
            pistol.SetActive(false);
            sniper.SetActive(false);
            rifle.SetActive(true);
        }
    }
}