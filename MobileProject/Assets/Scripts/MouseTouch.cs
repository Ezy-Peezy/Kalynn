using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouch : MonoBehaviour
{

    private Vector3 touchPosition;
    private Vector3 direction;

    public float speed; //our movement speed, making public so we can edit in inspector
    private Rigidbody2D rb2d; //reference we'll need to use any 2D physics

    // Start is called before the first frame update
    void Start()
    {
        //getting a reference to rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position).normalized;
            rb2d.velocity = direction * speed;
        }
        else
        {
            rb2d.velocity = (Vector2.zero);
        }
    }
}
