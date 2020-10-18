using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Text ammoDisplay;
    public Text scoreDisplay;

    public void UpdateAmmo(int ammo)
    {
        ammoDisplay.text = ammo.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreDisplay.text = score.ToString();
    }
}