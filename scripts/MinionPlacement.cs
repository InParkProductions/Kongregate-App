using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPlacement : MonoBehaviour {

	GameObject minion;
	Transform[] patrolPoint;


	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
				 

	}

	void OnMouseDown() {
		minion = Resources.Load("prefabs/LandMinion") as GameObject;
		GameObject instance = Instantiate(minion, transform.position, Quaternion.identity) as GameObject;

		instance.transform.parent = gameObject.transform.parent;

	}
}
