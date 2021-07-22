using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMove : MonoBehaviour
{
   
    float paddleSpeed = 25f;
    float directionY;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Resets paddle's velocity and position
    void PaddleReset()
    {
        transform.position = new Vector2(GameManager.leftPaddlePos.x, GameManager.leftPaddlePos.y) ;
        rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.acceleration.y * paddleSpeed;
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -2.25f, 2.25f));
    }

    // Velocity updated every 0.02 seconds (50 calls per second)
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(0f, directionY);
    }
  
  
}
