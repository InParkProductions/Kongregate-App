using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LandMinion : Minion {

	private Rigidbody rb;
	public int jumpSpeed;
	private bool isJumping;

	private enum State{
		patrol,
		attack
	}
	private State currentState;

	new void Start () {
		base.Start();
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		if(currentState == State.patrol)
		{
			commencePatrol();
		}
	}

	void commencePatrol()
	{
		//Get next position required to smoothly move to patrol point (current patrol point's position - transform) at a rate of moveSpeed
		Vector3 direction = (patrolPath[currentPatrolPoint].transform.position - transform.position).normalized * moveSpeed;

		// increase rigidbody speed until moveSpeed is reached
			if(rb.velocity.magnitude <= moveSpeed)

				rb.AddForce(direction * moveSpeed);

		// If transform position + (transform position - patrol point position) < searchRadius
		//	 search for next patrol point
			if(Vector3.Distance(transform.position, patrolPath[currentPatrolPoint].transform.position) <= searchRadius)
			{
				// if last point is reached begin patrol anew
				if(currentPatrolPoint == patrolPath.Count - 1)
				{
					currentPatrolPoint = 0;
				}
				else
				{
					// advance to next patrol point
					currentPatrolPoint++;
				}
			}
	}


	void OnTriggerEnter(Collider other)
	{
		if( other.gameObject.tag == "Jump Pad" && !isJumping)
		{
			rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
			isJumping = true;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if( isJumping && other.gameObject.tag == "Level Base")
		{
			isJumping = false;
		}
	}
}
