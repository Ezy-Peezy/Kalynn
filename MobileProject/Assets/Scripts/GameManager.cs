using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
   // private SpawnManager spawnManagerScript;
    private PlayerController playerControllerScript;

    public GameObject obstaclePrefab;
    public GameObject boltPrefab;
    private Vector3 spawnPos = new Vector3(-2, 0, 15);
    private Vector3 boltSpawnPos = new Vector3(1, 1, 15);
    private float startDelay = 3;
    private float repeatRate = 3;
    private float boltStartDelay = 5;
    private float boltRepeatRate = 5;

    // Start is called before the first frame update
    void Start()
    {
        //spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnBolt", boltStartDelay, boltRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

    }

    void SpawnBolt()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(boltPrefab, boltSpawnPos, boltPrefab.transform.rotation);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
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
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}
