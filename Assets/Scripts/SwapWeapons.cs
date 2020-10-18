using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class SwapWeapons : MonoBehaviour
{
    [SerializeField] private GameObject metalDetector, pistol, pistol2, sniper, sniper2, smg, smg2;
    private int weapongSelected = 2;
    private int hold = 2;

    private float timeToSwap = 0;
    private float detectionTime = 5f;

    private void Start()
    {
        StartCoroutine(DetectGuns(Random.Range(2, 5)));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > timeToSwap)
        {
            timeToSwap = Time.time + detectionTime;
            while (hold == weapongSelected)
            {
                hold = Random.Range(2, 8);
            }
            StartCoroutine(DetectGuns(hold));
            weapongSelected = hold;
        }
    }

    private void SwitchWeapon(int holder)
    {
        if (holder == 2)
        { //pistol
            pistol.SetActive(true); //
            sniper.SetActive(false);
            smg.SetActive(false);
            pistol2.SetActive(false);
            sniper2.SetActive(false);
            smg2.SetActive(false);
        }
        if (holder == 3)
        { //sniper
            pistol.SetActive(false);
            sniper.SetActive(true); //
            smg.SetActive(false);
            pistol2.SetActive(false);
            sniper2.SetActive(false);
            smg2.SetActive(false);
        }
        if (holder == 4)
        { //smg
            pistol.SetActive(false);
            sniper.SetActive(false);
            smg.SetActive(true); //
            pistol2.SetActive(false);
            sniper2.SetActive(false);
            smg2.SetActive(false);
        }
        if (holder == 5)
        { //pistol - 2
            pistol.SetActive(false);
            sniper.SetActive(false);
            smg.SetActive(false);
            pistol2.SetActive(true); //
            sniper2.SetActive(false);
            smg2.SetActive(false);
        }
        if (holder == 6)
        { //sniper - 2
            pistol.SetActive(false);
            sniper.SetActive(false);
            smg.SetActive(false);
            pistol2.SetActive(false);
            sniper2.SetActive(true); //
            smg2.SetActive(false);
        }
        if (holder == 7)
        { //smg - 2
            pistol.SetActive(false);
            sniper.SetActive(false);
            smg.SetActive(false);
            pistol2.SetActive(false);
            sniper2.SetActive(false);
            smg2.SetActive(true); //
        }
    }

    private IEnumerator DetectGuns(int holder)
    {
        //Metal Detector Logic
        metalDetector.SetActive(true);
        pistol.SetActive(false);
        sniper.SetActive(false);
        smg.SetActive(false);
        pistol2.SetActive(false);
        sniper2.SetActive(false);
        smg2.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        metalDetector.SetActive(false);
        SwitchWeapon(holder);
    }
}