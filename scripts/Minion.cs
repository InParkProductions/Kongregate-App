using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Minion : MonoBehaviour {

	protected List<Transform> patrolPath;

	// Determine when to look for next object when nearing targetted patrol point
	// If transform position + (transform position - patrol point position) < searchRadius
	//	 search for next patrol point

		public float searchRadius;
		public int moveSpeed;
	// currentPatrolPoint[0] = designated station transform position

		protected int currentPatrolPoint = 0;

	public float attackRange;

	// Player reference used to determine when minion engages and attacks the player
	protected Transform player;

	// Use this for initialization
	protected void Start () {
		// Assign a patrol path to the minion

			patrolPath = new List<Transform>( GameManager.getPatrolPath(gameObject.transform) );

			player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnDrawGizmos()
	{
		// Monitor attack range
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
