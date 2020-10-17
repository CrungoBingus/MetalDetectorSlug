using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 30.0f;
    private int nmbTilesOnScreen = 10;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerTransform.position.x > (spawnZ - nmbTilesOnScreen * tileLength))
        {
            SpawnTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.right * spawnZ;
        spawnZ += tileLength;
    }
}