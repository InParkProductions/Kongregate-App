using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Minion : MonoBehaviour {

	private List<Transform> patrolPath;
	public float searchRadius;
	private int currentPatrolPoint = 0;

	private enum State {
		patrol,
		attack,
	}

	private State currentState;
	// Use this for initialization
	void Start () { 
		patrolPath = new List<Transform>( GameManager.getPatrolPath(gameObject.transform) );


		foreach(Transform path in patrolPath)
		{
			Debug.Log(path.localPosition);
		}
		currentState = State.patrol;

	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == State.patrol)
			commencePatrol();

	}

	void commencePatrol(){
		Debug.Log(currentPatrolPoint);
		transform.position = Vector3.Slerp(transform.position, patrolPath[currentPatrolPoint].position, 1 * Time.deltaTime);
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
