using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementMenu : MonoBehaviour {

	private CameraController mainCameraScript;
	private Transform mainCameraObject;
	private float cameraMin;
	private float cameraMax;
	private Vector3 menuPos;
	// Use this for initialization
	void Start () {
		mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera").transform;
		mainCameraScript = mainCameraObject.GetComponent<CameraController>();
	}

	void Update ()
	{
		//	MOVE CAMERA WITH MOUSE
		//	======================
			cameraMin = mainCameraScript.getMinPos();
			cameraMax = mainCameraScript.getMaxPos();

			menuPos = transform.position;

	}

	// Update is called once per frame
	void LateUpdate () {

			//get current mouse position in Unity units
		   		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);

		    /* Move camera if the following conditions are met:
		    	 * The camera has not exceeded the game wold space.
		    	 * The camera has exceeded the game world space and the mouse is positioned opposite to world end/start.
		    */

			if(cameraMin >= GameManager.getWorldStart() && cameraMax <= GameManager.getWorldEnd() && 
			  (mousePos.x <= cameraMin + mainCameraScript.getMovementOffset() || mousePos.x >= cameraMax - mainCameraScript.getMovementOffset() )) {
			Debug.Log("Menu Pos to Move: " + (menuPos + (mousePos - menuPos)));
			Debug.Log("Menu Pos to Move 2: " + (transform.position + (mousePos - transform.position)));
					//smoothly move camera with mouse along the x-axis while keeping y and z axis constraint to starting positions
						transform.position = Vector3.Lerp(transform.position, menuPos + (mousePos - menuPos), Time.deltaTime * mainCameraScript.getMoveSpeed());

			}

			if(cameraMin < GameManager.getWorldStart())
			{
				Vector3 cameraAdjusment = transform.position + new Vector3(mainCameraScript.getBoundsAdjustment(), 0, 0);
				transform.position = Vector3.Lerp(transform.position, cameraAdjusment, Time.deltaTime * mainCameraScript.getAdjustmentSpeed());
			}
			else
			if(cameraMax > GameManager.getWorldEnd())
			{
				Vector3 cameraAdjusment = transform.position - new Vector3(mainCameraScript.getBoundsAdjustment(), 0, 0);
				transform.position = Vector3.Lerp(transform.position, cameraAdjusment, Time.deltaTime * mainCameraScript.getAdjustmentSpeed());

			}
			// <!! MOVE CAMERA WITH MOUSE !!>
	}
}
