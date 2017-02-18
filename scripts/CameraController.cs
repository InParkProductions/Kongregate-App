using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	private Vector3 cameraPos;
	private Vector3 menuPos;
	public float moveSpeed;
	private Transform placementMenuObject;
	private PlacementMenu placementMenuScript;

	private float cameraMin;
	private float cameraMax;
	public float movementOffset;
	public float boundsAdjustment;
	public int adjustmentSpeed;

	void Start () {
		placementMenuObject = GameObject.FindGameObjectWithTag("PlacementMenu").transform;
	}

	void Update () {
		// store camera's current position for mouse position comparison
		cameraPos = transform.position;
		menuPos = placementMenuObject.position;


		// DEFINE WORLD BEGINNING AND END
		// ==============================
			 cameraMin = cameraPos.x - Camera.main.orthographicSize * Screen.width / Screen.height;
			 cameraMax = Camera.main.orthographicSize * Screen.width / Screen.height + cameraPos.x;

		

		    /* Move camera if the following conditions are met:
		    	 * The camera has not exceeded the game wold space.
		    	 * The camera has exceeded the game world space and the mouse is positioned opposite to world end/start.
		    */

		// <!! MOVE CAMERA WITH MOUSE !!>
		//

		// QUIT GAME IN APPLICATION
		// ========================

			if( Input.GetKeyDown ( KeyCode.Escape ) )
			{
				Application.Quit ();
			}

	}

	public float getMinPos()
	{
		return cameraMin;
	}

	public float getMaxPos()
	{
		return cameraMax;
	}

	public float getMoveSpeed()
	{
		return moveSpeed;
	}

	public float getMovementOffset()
	{
		return movementOffset;
	}

	public float getBoundsAdjustment()
	{
		return boundsAdjustment;
	}

	public float getAdjustmentSpeed()
	{
		return adjustmentSpeed;
	}

	void FixedUpdate()
	{
		//	MOVE CAMERA WITH MOUSE
		//	======================

			//get current mouse position in Unity units
		   		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraPos.y, cameraPos.z);
		Vector3 mousePosFromMenu = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, menuPos.y, menuPos.z);

		if(cameraMin >= GameManager.getWorldStart() && cameraMax <= GameManager.getWorldEnd() && 
				   (mousePos.x <= cameraMin + movementOffset || mousePos.x >= cameraMax  - movementOffset)) {

					//smoothly move camera with mouse along the x-axis while keeping y and z axis constraint to starting positions
						transform.position = Vector3.Lerp(transform.position, cameraPos + (mousePos - cameraPos), Time.deltaTime * moveSpeed);
						placementMenuObject.position = Vector3.Lerp(placementMenuObject.position, menuPos + (mousePosFromMenu - menuPos), Time.deltaTime * moveSpeed);

			    }
		if(cameraMin < GameManager.getWorldStart())
		{
			Vector3 cameraAdjusment = transform.position + new Vector3(boundsAdjustment, 0, 0);
			Vector3 menuAdjustment = placementMenuObject.position + new Vector3(boundsAdjustment, 0, 0);
			transform.position = Vector3.Lerp(transform.position, cameraAdjusment, Time.deltaTime * adjustmentSpeed);
			placementMenuObject.position = Vector3.Lerp(placementMenuObject.position, menuAdjustment, Time.deltaTime * adjustmentSpeed);
		}
		else
		if(cameraMax > GameManager.getWorldEnd())
		{
			Vector3 cameraAdjustment = transform.position - new Vector3(boundsAdjustment, 0, 0);
			Vector3 menuAdjustment = placementMenuObject.position - new Vector3(boundsAdjustment, 0, 0);
			transform.position = Vector3.Lerp(transform.position, cameraAdjustment, Time.deltaTime * adjustmentSpeed);
			placementMenuObject.position = Vector3.Lerp(placementMenuObject.position, menuAdjustment, Time.deltaTime * adjustmentSpeed);
		}
	}
}
