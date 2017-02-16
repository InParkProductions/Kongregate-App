using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//	PLAYER PROPERTIES
	//	=================

	public int health;
	//private int score;
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;

	//	JUMP PROPERTIES
	//	===============

	public int jumpVelocity;
	public bool isJumping;
	private RaycastHit hit;


	//	MOVEMENT PARAMETERS
	//	===================

	private Rigidbody rb;
	private Vector3 moveDirection;
	public float moveSpeed;

	private Vector3 playerSpawn;
	public bool powerupActive;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		isJumping = false;
		powerupActive = false;

		playerSpawn = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		Debug.Log("Player Velocity: " + rb.velocity);
//		float translation = Input.GetAxis("Vertical") * speed;
//		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
//		translation *= Time.deltaTime;
//		rotation *= Time.deltaTime;
//		transform.Translate(0, 0, translation);
//		transform.Rotate(0, rotation, 0);
//		if (Input.GetButtonDown ("Jump")) {
//			anim.SetBool ("isJumping", true);
//		} 
//		else 
//		
//		{
//			anim.SetBool ("isJumping", false);
//		}

//        if(translation != 0)
//        {
//        	anim.SetBool("isRunning", true);
//        }
//        else
//        {
//        	anim.SetBool("isRunning", false);
//        }

		if(transform.position.y < -2){
			transform.position = playerSpawn;
			health -= 1;
			GameObject.Find("HealthManager").SendMessage("updateHealth", health);
		}

		if( !isJumping )
		{
			if( Input.GetKeyDown ( KeyCode.Space ) )
			{
				//	PLAYER JUMPING AND CANNOT DOUBLE JUMP
				//	=====================================

				rb.AddForce ( new Vector3(0, jumpVelocity, 0), ForceMode.Impulse);
				isJumping = true;
			}


		}
		else
		if(isJumping){
			//Ref: https://www.youtube.com/watch?v=6agwCUaMNWI (How to Raycast in Unity)

			//  SPECIFY RAY DIRECTION
			//	=====================

			//Vector3 down = transform.TransformDirection ( Vector3.down );

			//	CREATE RAY AND RETURN TRUE IF HIT
			//	=================================

//			if ( Physics.SphereCast(transform.position, 0.5f, down, out hit, 0.1f ) )
//			{
//				if( hit.collider.gameObject.tag == "Healthy" )
//				{
//					//	RETRIEVE SCRIPT INFORMATION OF COLLIDING HEALTHY
//					//	================================================
//
//					healthyState = ( Healthy ) hit.collider.GetComponent ( typeof ( Healthy ) );
//
//					if( !healthyState.getConsumedState () )
//					{
//						//	PLAYER CONSUMES HEALTHY
//						//	=======================
//
//						hit.collider.SendMessage( "consume" );
//						score += 15;
//						GameObject.Find("GameManager").GetComponent<GameManager>().IncreaseScore();
//					}
//				}
//				if( hit.collider.gameObject.tag == "Water"){
//					Debug.Log("Blah");
//				}
//			}
		}

		//	RETRIEVE INPUT
		//	==============

		moveDirection = new Vector3 ( Input.GetAxis ( "Horizontal" ), 0, Input.GetAxis ( "Vertical" ) );

		// 	INCREASE RIGIDBODY SPEED UNTIL MOVESPEED IS REACHED
		//	==================================================
		if ( rb.velocity.magnitude < moveSpeed ){
			rb.AddForce ( moveDirection * moveSpeed);
		}
	}

	//	FLIPS isJumping TO MAKE JUMPING POSSIBLE
	//	========================================

	void OnCollisionEnter ( Collision other )
	{
		if( other.gameObject.tag == "Ground" )
		{
			isJumping = false;
		}


		if( other.gameObject.tag == "Unhealthy" || other.gameObject.tag == "Jumper")
		{
			//http://answers.unity3d.com/questions/750235/how-to-add-opposite-force-of-current-direction.html
			health -= 1;
			rb.AddForce(-rb.velocity * 0.7f, ForceMode.Impulse);
			GameObject.Find("HealthManager").SendMessage("updateHealth", health);
		}
	}


//	public int GetPlayerScore ()
//	{
//		return score;
//	}
}
