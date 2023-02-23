using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars;
    public int maxX;
    public int maxY;
    public int minZ;
    public int maxZ;

    public void Start()
    {
        float X = Random.Range(-maxX, maxX);
        float Y = Random.Range(-maxY, maxY);
        float Z = Random.Range(minZ, maxZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
