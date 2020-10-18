using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UiController UICont;
    public int score = 1000;

    private void FixedUpdate()
    {
        UICont.UpdateScore(score);
    }
}