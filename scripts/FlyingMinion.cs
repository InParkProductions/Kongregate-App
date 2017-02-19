using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingMinion : Minion {

	private enum State {
		patrol,
		attack,
	}

	private State currentState;
	// Use this for initialization
	new void Start () { 
		currentState = State.patrol;

	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == State.patrol)
			commencePatrol();

	}

	void commencePatrol(){

		// If player is within attack range, engage and attack the player
			if(Vector3.Distance(transform.position, player.position) <= attackRange)
			{
				// smoothly move to patrol point (current patrol point's position - transform) at a rate of moveSpeed/4
					transform.position = Vector3.Slerp(transform.position, player.position, moveSpeed/4 * Time.deltaTime);
			}
			else
			{
				transform.position = Vector3.Slerp(transform.position, patrolPath[currentPatrolPoint].position, moveSpeed * Time.deltaTime);

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

	}
}
