using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	private Vector3 cameraPos;
	public float moveSpeed;
	public GameManager gameManager;

	void Start () {
		cameraPos = transform.position;
	}

	void Update () {

		//store the two edge points of the camera
		//=======================================
		float cameraMin = Camera.main.ScreenToWorldPoint(transform.position).x;
		float cameraMax = Camera.main.ViewportToWorldPoint(transform.position).x;

		Debug.Log(cameraMax);
		//if(cameraMin <= gameManager.getWorldStart())
			
		//Debug.Log(cameraMax);

		//	MOVE CAMERA WITH MOUSE UNTIL WORLD EDGE IS HIT
		//	==============================================


			//if(cameraMin >= gameManager.getWorldStart() && cameraMax <= gameManager.getWorldEnd()){

				//move camera with mouse along the x-axis while keeping y and z axis constraint to starting positions
				Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraPos.y, cameraPos.z);

				//smooth transition
				transform.position = Vector3.Lerp(transform.position, cameraPos + (mousePos - cameraPos), Time.deltaTime * moveSpeed);

		    //}

		// QUIT GAME IN APPLICATION
		// ========================

		if( Input.GetKeyDown ( KeyCode.Escape ) )
		{
			Application.Quit ();
		}
	}
}
