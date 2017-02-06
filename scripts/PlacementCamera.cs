using UnityEngine;
using System.Collections;

public class PlacementCamera : MonoBehaviour {
	public GameObject player;
	public Material skyGraphic;
	public float moveSpeed;

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	void Start () {
		RenderSettings.skybox = skyGraphic;
	}

	void Update () {
		Vector3 playerPos = player.transform.position;
		//	RETAIN SAME DISTANCE FROM PLAYER
		//	================================
		Debug.Log(playerPos.x);
		if(playerPos.x > -7.5f && playerPos.x < 8.5f)
		{
			Vector3 newPos = new Vector3(playerPos.x, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);
		}
		// QUIT GAME IN APPLICATION
		// ========================

		if( Input.GetKeyDown ( KeyCode.Escape ) )
		{
			Application.Quit ();
		}
	}
}