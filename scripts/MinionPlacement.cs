using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPlacement : MonoBehaviour {

	public Transform[] station;
	GameObject minion;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
				 

	}

	void OnMouseDown() {
		minion = Resources.Load("prefabs/Minion") as GameObject;
		Instantiate(minion, transform.position, Quaternion.identity);
	}
}
