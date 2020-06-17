using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject backgroundPrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private Vector3 spawnPos2 = new Vector3(157, 9, 4);
//    private float startDelay2 = 2.0f;
    public float repeatRate2 = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnBackground", 0, repeatRate2);
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
        Instantiate(backgroundPrefab, spawnPos2, backgroundPrefab.transform.rotation);
    }
}
