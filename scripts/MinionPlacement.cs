using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPlacement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if(transform.position.y > 0.5 && transform.position.y < 8)
		transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
		//Debug.Log(transform.position);
	}
}
