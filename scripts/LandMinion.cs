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

	void Start () {
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
		Vector3 direction = (patrolPath[currentPatrolPoint].transform.position - transform.position).normalized * moveSpeed;
		if(rb.velocity.magnitude <= moveSpeed)
		rb.AddForce(direction * moveSpeed);

		Debug.Log(Vector3.Distance(transform.position, direction));
		if(Vector3.Distance(transform.position, patrolPath[currentPatrolPoint].transform.position) <= searchRadius)
		{
			if(currentPatrolPoint == patrolPath.Count - 1)
			{
				currentPatrolPoint = 0;
			}
			else
			{
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
