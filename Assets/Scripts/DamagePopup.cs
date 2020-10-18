using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private float moveHold = 0f;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        Destroy(gameObject, 0.5f);
        moveHold = Random.Range(-0.005f, 0.005f);
    }

    public void Setup(string DamageAmount)
    {
        textMesh.SetText(DamageAmount);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + moveHold, transform.position.y + 0.01f, transform.position.z);
    }
}