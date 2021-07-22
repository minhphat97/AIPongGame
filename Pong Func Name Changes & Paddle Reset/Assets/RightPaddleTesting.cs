using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleTesting : MonoBehaviour
{

  
    public float boundY = 2.25f;
    private Rigidbody2D rigidBody;
 
    private BallMovement ball;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }
    void PaddleReset()
    {
        transform.position = new Vector2(GameManager.rightPaddlePos.x, GameManager.rightPaddlePos.y);
        rigidBody.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.y = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>().transform.position.y;
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(pos.y, -2.25f, 2.25f));

    }
}
