using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	private Rigidbody2D rigidBody;
    
	// Ball's intial movement randomly selected
	void BallStart() {
    	float rand = Random.Range(0, 4);
    	
		if(rand < 1) {
    		rigidBody.AddForce(new Vector2(25, -20));
		} 
		else if(rand<2) {
        			rigidBody.AddForce(new Vector2(-25, -20));
		}
		else if(rand<3) {
        			rigidBody.AddForce(new Vector2(-25, 20));
    	}
		else {
        			rigidBody.AddForce(new Vector2(25, 20));
    	}
	}

	// Start is called before the first frame update
    void Start()
    {
		rigidBody = GetComponent<Rigidbody2D>();
  		Invoke("BallStart", 2); 
    }
	
	// Resets ball's velocity and position
	void BallReset(){
		transform.position = Vector2.zero;
		rigidBody.velocity = Vector2.zero;
	}

	// Resets the ball and starts a new round
	void GameRestart(){
    	BallReset();
    	Invoke("BallStart", 1);
	}

	// Set minimum x speed to 4m/s to keep game moving quickly
	void OnCollisionEnter2D (Collision2D collision) {
    		if(collision.collider.CompareTag("Player")){
        			Vector2 vel;
        			vel.x = rigidBody.velocity.x;
        			vel.y = (rigidBody.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
			if(vel.x < 4)
			{
				if(vel.x > -4)
				{
					if(vel.x > 0)
					{
						vel.x = 4;
					}
					else
					{
						vel.x = -4;
					}
				}
			}
        			rigidBody.velocity = vel;
		}
	}
}
