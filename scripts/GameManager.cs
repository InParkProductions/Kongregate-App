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

		//Find objects that represent the start and end of a level
			Transform baseOfLevelStart = GameObject.FindGameObjectWithTag("Start Level Base").transform;
			Transform baseOfLevelEnd = GameObject.FindGameObjectWithTag("End Level Base").transform;

		//Determine origin of starting object and world position of ending object's position and it's width
			worldStart = startingArea.position.x - getObjectsCentrePoint(baseOfLevelStart);
			worldEnd = endingArea.position.x + getObjectsCentrePoint(baseOfLevelEnd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static float getObjectsCentrePoint (Transform gameObject) {

		//return gameObject's width in Unity units / 2
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
		// Initialise patrolPath as a dynamically sizes list of patrol points
			List<Transform> patrolPath = new List<Transform>();

		// Find the minions designated patrol path at spawned patrol station
			foreach(Transform child in gameObject.parent)
			{
				// If this gameObjects sibling is a patrol point  
					if(child.name == "PatrolPoints")
					{
						foreach(Transform point in child)
						{
							// Add all the points to the patrolPath
							patrolPath.Add(point);
						}
					}
			}

		// Give minion the patrolPath data
			return patrolPath;
	}

	public static Vector3 MoveObjectAlongScreen(Vector3 currentPos, Vector3 nextPos, float speed)
	{
			Vector3 distanceToNextPos = currentPos + (nextPos - currentPos);

		// Return the action required to move gameObject to next position
			return Vector3.Lerp(currentPos, distanceToNextPos, Time.deltaTime * speed);
	}
}
