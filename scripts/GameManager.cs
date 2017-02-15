using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform startingArea;
	public Transform endingArea;
	static float worldStart;
	static float worldEnd;

	// Use this for initialization
	void Start () {
		Transform baseOfLevel = GameObject.FindGameObjectWithTag("Level Base").transform;
		worldStart = startingArea.position.x - getObjectsCentrePoint(baseOfLevel);
		worldEnd = endingArea.position.x + getObjectsCentrePoint(baseOfLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static float getObjectsCentrePoint (Transform gameObject) {

		//width in unity units / 2
		return gameObject.localScale.x / 2;
	}

	public static float getWorldStart () { 
		return worldStart;
	}

	public static float getWorldEnd () {
		return worldEnd;
	}

	public static List<Transform> getPatrolPath(Transform gameObject)
	{
		Transform obj = gameObject;
		List<Transform> patrolPath = new List<Transform>();

		foreach(Transform child in obj.parent)
		{
			if(child.name == "PatrolPoints")
			{
				foreach(Transform point in child)
				{
					patrolPath.Add(point);
				}
			}
		}

		return patrolPath;
	}
}
