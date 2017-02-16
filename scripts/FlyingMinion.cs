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
	void Start () { 
		currentState = State.patrol;

	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == State.patrol)
			commencePatrol();

	}

	void commencePatrol(){
		Debug.Log(currentPatrolPoint);

		if(Vector3.Distance(transform.position, player.position) <= attackRange)
		{
			transform.position = Vector3.Slerp(transform.position, player.position, moveSpeed/4 * Time.deltaTime);
		}
		else
		{
			transform.position = Vector3.Slerp(transform.position, patrolPath[currentPatrolPoint].position, moveSpeed * Time.deltaTime);

			if(Vector3.Distance(transform.position, patrolPath[currentPatrolPoint].position) <= searchRadius)
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

	}
}
