using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform baseOfLevel;
	float worldStart;
	float worldEnd;

	// Use this for initialization
	void Start () {
		Transform baseOfLevel = GameObject.FindGameObjectWithTag("Level Base").transform;
		worldStart = baseOfLevel.position.x - getObjectsCentrePoint(baseOfLevel);
		worldEnd = baseOfLevel.position.x + getObjectsCentrePoint(baseOfLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float getObjectsCentrePoint (Transform gameObject) {

		//width in unity units / 2
		return gameObject.localScale.x / 2;
	}

	public float getWorldStart () { 
		return worldStart;
	}

	public float getWorldEnd () {
		return worldEnd;
	}
}
