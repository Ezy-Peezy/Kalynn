using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject boltPrefab;
    private Vector3 spawnPos = new Vector3(-2, 0, 15);
    private Vector3 boltSpawnPos = new Vector3(1, 1, 15);
    private float startDelay = 3;
    private float repeatRate = 3;
    private float boltStartDelay = 5;
    private float boltRepeatRate = 5;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnBolt", boltStartDelay, boltRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }

    void SpawnBolt()
    {
        Instantiate(boltPrefab, boltSpawnPos, boltPrefab.transform.rotation);
    }
}
