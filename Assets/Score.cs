using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private UiController UICont;
    public int score;
    private int timer;

    private void FixedUpdate()
    {
        timer++;
        if (timer > 60)
        {
            score++;
            UICont.UpdateScore(score);
            timer = 0;
        }
    }
}