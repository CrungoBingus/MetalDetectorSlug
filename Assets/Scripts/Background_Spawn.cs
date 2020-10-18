using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Spawn : MonoBehaviour
{
    public GameObject BG;
    private int counter = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x > 570 * counter)
        {
            counter++;
            Vector3 BG_POS;
            BG_POS.x = 500 * counter - 1;
            BG_POS.y = 25f;
            BG_POS.z = -18f;

            Quaternion QUAT = BG.transform.rotation;

            BG.transform.position = BG_POS;
            BG.transform.rotation = QUAT;
          

            
           
        }
    }
}
