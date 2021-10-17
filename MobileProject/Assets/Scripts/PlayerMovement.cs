using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    protected Joystick joystick;
    public bool gameOver;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 5f, joystick.Vertical * 5f, rigidbody.velocity.z * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            spawnManager.UpdateScore(1);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            spawnManager.GameOver();
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
