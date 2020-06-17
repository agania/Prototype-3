using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject backgroundPrefab;

    private Vector3 spawnPos = new Vector3(225, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private Vector3 buildingsSpawnPos = new Vector3(157, 9, 10);
    private Vector3 buildings2SpawnPos = new Vector3(157, 9, -12);
    //    private float startDelay2 = 2.0f;
    public float repeatRate2 = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnBackground", 0, repeatRate2);//startDelay2 -> 0
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
    void SpawnBackground()
    {
        Instantiate(backgroundPrefab, buildingsSpawnPos, backgroundPrefab.transform.rotation);
        Instantiate(backgroundPrefab, buildings2SpawnPos, backgroundPrefab.transform.rotation);
    }
}
