using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSideWalls : MonoBehaviour
{
    GameObject paddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindGameObjectWithTag("HumanPaddle");
    }

    // Updates game score and resets ball and paddles if ball hits left or right wall
    void OnTriggerEnter2D(Collider2D wallHit)
    {
        if (wallHit.name == "Ball")
        {
            string wall = transform.name;
            GameManager.Score(wall);
            wallHit.gameObject.SendMessage("GameRestart", 1.0f, SendMessageOptions.RequireReceiver);
            paddle.gameObject.SendMessage("PaddleReset", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
}
