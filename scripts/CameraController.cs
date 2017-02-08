using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	private Vector3 cameraPos;
	public float moveSpeed;
	public GameManager gameManager;

	void Start () {
		
	}

	void Update () {
		// store camera's current position for mouse position comparison
		cameraPos = transform.position;

		// DEFINE WORLD BEGINNING AND END
		// ==============================
			 float cameraMin = cameraPos.x - Camera.main.orthographicSize * Screen.width / Screen.height;
			 float cameraMax = Camera.main.orthographicSize * Screen.width / Screen.height + cameraPos.x;


		//	MOVE CAMERA WITH MOUSE
		//	======================

			//get current mouse position in Unity units
		   		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraPos.y, cameraPos.z);

		    /* Move camera if the following conditions are met:
		    	 * The camera has not exceeded the game wold space.
		    	 * The camera has exceeded the game world space and the mouse is positioned opposite to world end/start.
		    */

				if(cameraMin >= gameManager.getWorldStart() && cameraMax <= gameManager.getWorldEnd() || 
				   cameraMax > gameManager.getWorldEnd() && mousePos.x <= cameraPos.x				  ||
				   cameraMin < gameManager.getWorldStart() && mousePos.x >= cameraPos.x                 ) {

					//smoothly move camera with mouse along the x-axis while keeping y and z axis constraint to starting positions
						transform.position = Vector3.Lerp(transform.position, cameraPos + (mousePos - cameraPos), Time.deltaTime * moveSpeed);

			    }

		// QUIT GAME IN APPLICATION
		// ========================

			if( Input.GetKeyDown ( KeyCode.Escape ) )
			{
				Application.Quit ();
			}
	}
}
