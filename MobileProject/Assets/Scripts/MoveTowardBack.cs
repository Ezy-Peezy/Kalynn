using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardBack : MonoBehaviour
{
    private float speed = 15.0f;
    private PlayerMovement playerMovementScript;
    private SpawnManager spawnManager;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
