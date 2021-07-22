using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int player1Score = 0;
    public static int player2Score = 0;
    public static Vector2 leftPaddlePos;
    public static Vector2 rightPaddlePos;
    public GUISkin scoreFormat;
    GameObject ball;
    GameObject paddle;

    // Start is called before the first frame update
    void Start()
    {
        leftPaddlePos = new Vector2(-4.5f, 0f);
        rightPaddlePos = new Vector2(0f, 4.5f);
        ball = GameObject.FindGameObjectWithTag("Ball");
        paddle = GameObject.FindGameObjectWithTag("HumanPaddle");
    }

    // Player's score increased by 1 if ball hits left or right wall
    public static void Score(string wall)
    {
        if (wall == "RightWall")
        {
            player1Score++;
        }

        else if (wall == "LeftWall")
        {
            player2Score++;
        }
    }

    // Displays scores, restart button and game winning message
    void OnGUI()
    {
        GUI.backgroundColor = Color.cyan;
        GUI.contentColor = Color.black;
        GUI.skin = scoreFormat;
        GUI.Label(new Rect(Screen.width / 2 - 162, 20, 100, 100), "" + player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 162, 20, 100, 100), "" + player2Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "Restart"))
        {
            player1Score = 0;
            player2Score = 0;
            ball.SendMessage("GameRestart", 0.5f, SendMessageOptions.RequireReceiver);
            paddle.SendMessage("PaddleReset", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (player1Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 250, 250, 2500, 1000), "PLAYER ONE WINS");
            ball.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
            paddle.SendMessage("PaddleReset", 0.5f, SendMessageOptions.RequireReceiver);
        }

        else if (player2Score == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 250, 250, 2500, 1000), "PLAYER TWO WINS");
            ball.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
            paddle.SendMessage("PaddleReset", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
}
