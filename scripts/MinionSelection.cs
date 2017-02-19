using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSelection : MonoBehaviour {

	private GameObject[] stations;
	// Use this for initialization

	void Start () {
		stations = GameObject.FindGameObjectsWithTag("Station");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
		foreach(GameObject station in stations)
		{
			MinionPlacement placementScript = station.GetComponent<MinionPlacement>();
			placementScript.setMinionToSummon(gameObject.name);
		}
	}
}
