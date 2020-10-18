using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastRunsScore : MonoBehaviour
{
    public Text lastRunsScore;

    private void Start()
    {
        lastRunsScore.text = "Score: " + PlayerPrefs.GetInt("LastRunsScore").ToString();
    }
}