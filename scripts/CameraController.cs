using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 distance;
	public Material skyGraphic;

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	void Start () {
		distance = player.transform.position - transform.position;
		RenderSettings.skybox = skyGraphic;
	}

	void Update () {
		 
		//	RETAIN SAME DISTANCE FROM PLAYER
		//	================================

		transform.position = player.transform.position - distance;

		// QUIT GAME IN APPLICATION
		// ========================

		if( Input.GetKeyDown ( KeyCode.Escape ) )
		{
			Application.Quit ();
		}
	}
}
