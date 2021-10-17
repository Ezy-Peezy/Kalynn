using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    public bool gameOver;
    private Button button;
    public int difficulty;

    //public GameObject obstaclePrefab;
    //public GameObject boltPrefab;
    //private Vector3 spawnPos = new Vector3(-2, 0, 15);
    private float spawnRangeX = 3;
    private float spawnRangeY = 3;
    private float spawnPosZ = 15;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    //private Vector3 boltSpawnPos = new Vector3(1, 1, 15);
   // private float boltSpawnRangeX = 3;
    //private float boltSpawnPosZ = 15;
    //private float boltStartDelay = 5;
    //private float boltRepeatRate = 5;
    
    private PlayerMovement playerMovementScript;
    private MoveTowardBack moveTowardBackScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // InvokeRepeating("SpawnBolt", boltStartDelay, boltRepeatRate);
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
        moveTowardBackScript = GameObject.Find("Obstacle").GetComponent<MoveTowardBack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
        if (playerMovementScript.gameOver == false)
        {
            Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOver = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameOver = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        
    }
}
