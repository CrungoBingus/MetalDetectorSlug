using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gameover());
    }

    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Menu");
    }
}
