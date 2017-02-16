using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Minion : MonoBehaviour {

	protected List<Transform> patrolPath;

	public float searchRadius;
	public int moveSpeed;
	protected int currentPatrolPoint = 0;

	public float attackRange;
	protected Transform player;

	// Use this for initialization
	protected void Start () { 
		patrolPath = new List<Transform>( GameManager.getPatrolPath(gameObject.transform) );
		player = GameObject.FindGameObjectWithTag("Player").transform;

		foreach(Transform path in patrolPath)
		{
			Debug.Log(path.localPosition);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if( other.gameObject.tag == "Jump Pad" )
		{
			Debug.Log("blah");
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
