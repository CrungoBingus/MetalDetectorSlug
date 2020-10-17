using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private Transform arm; // apply self
    private Vector3 armPos;
    private float angle;

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 7.55f; //distance between camera and player
        armPos = Camera.main.WorldToScreenPoint(arm.position);
        mousePosition.x = mousePosition.x - armPos.x;
        mousePosition.y = mousePosition.y - armPos.y;
        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}