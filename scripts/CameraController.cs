using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// CAMERA STARTING DISTANCE FROM PLAYER
	// ====================================

	private Vector3 cameraPos;
	private Vector3 menuPos;
	private float cameraStartRenderingAt;
	private float cameraFinishRenderingAt;
	public float moveSpeed;

	private Transform placementMenu;

	public float moveMapAreaLength;
	public float boundsAdjustment;
	public int adjustmentSpeed;

	void Start () {
		// Find placement menu object
		placementMenu = GameObject.FindGameObjectWithTag("PlacementMenu").transform;
	}

	void FixedUpdate()
	{
		// store camera's current position for mouse position comparison
		cameraPos = transform.position;
		menuPos = placementMenu.position;


		// DEFINE CURRENT WORLD VIEW
		// ==============================

			 cameraStartRenderingAt = cameraPos.x - Camera.main.orthographicSize * Screen.width / Screen.height;
			 cameraFinishRenderingAt = Camera.main.orthographicSize * Screen.width / Screen.height + cameraPos.x;

		// <!! DEFINE CURRENT WORLD VIEW !!>


		//	MOVE CAMERA WITH MOUSE
		//	======================

			//get current mouse position in Unity units

		   		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraPos.y, cameraPos.z);
				Vector3 mousePosFromMenu = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, menuPos.y, menuPos.z);



		    /* Move camera if the following conditions are met:
		    	 * The camera has not exceeded the game world bounds and mouse is position in move map area.
		    	 * The camera has exceeded the game world bounds and the mouse is positioned opposite to world end/start move map area.
		    */

				if(   getRenderStart() >= GameManager.getWorldStart()    &&     getRenderEnd() <= GameManager.getWorldEnd()       && 
				   (  mousePos.x <= getRenderStart() + getMoveMapArea()  ||     mousePos.x >= getRenderEnd() - getMoveMapArea())) {

					   // Smoothly move camera and menu with mouse along the x-axis while keeping y and z axis constraint to starting positions
						   transform.position = GameManager.MoveObjectAlongScreen(cameraPos, mousePos, moveSpeed);
						   placementMenu.position = GameManager.MoveObjectAlongScreen(menuPos, mousePosFromMenu, moveSpeed);

				    }
			// If camera view has exceeded world size adjust the view to the nearest world view

				if( getRenderStart() < GameManager.getWorldStart() )
				{
					Vector3 cameraAdjustment = CalculateBoundsAdjustment(cameraPos, true);
					Vector3 placementMenuAdjustment = CalculateBoundsAdjustment(menuPos, true);

					MoveInBounds(transform, cameraAdjustment);
					MoveInBounds(placementMenu, placementMenuAdjustment);
				}
				else
				if(getRenderEnd() > GameManager.getWorldEnd())
				{
					Vector3 cameraAdjustment =  CalculateBoundsAdjustment(cameraPos, false);
					Vector3 placementMenuAdjustment = CalculateBoundsAdjustment(menuPos, false);

					MoveInBounds(transform, cameraAdjustment);
					MoveInBounds(placementMenu, placementMenuAdjustment);
				}

		// <!! MOVE CAMERA WITH MOUSE !!>

		// QUIT GAME IN APPLICATION
		// ========================

			if( Input.GetKeyDown ( KeyCode.Escape ) )
			{
				Application.Quit ();
			}
	}

	public float getRenderStart ()
	{
		return cameraStartRenderingAt;
	}

	public float getRenderEnd ()
	{
		return cameraFinishRenderingAt;
	}

	public float getMoveSpeed ()
	{
		return moveSpeed;
	}

	public float getMoveMapArea ()
	{
		return moveMapAreaLength;
	}

	public float getBoundsAdjustment ()
	{
		return boundsAdjustment;
	}

	public float getAdjustmentSpeed ()
	{
		return adjustmentSpeed;
	}

	private Vector3 CalculateBoundsAdjustment(Vector3 currentPositionOfObject, bool fromWorldStart)
	{
		if(fromWorldStart)
			return ( currentPositionOfObject + new Vector3(boundsAdjustment, 0, 0) );
		else
			return ( currentPositionOfObject - new Vector3(boundsAdjustment, 0, 0) );
	}

	private void MoveInBounds (Transform gameObject, Vector3 adjustmentParams)
	{
		//smoothly move object towards game environment at a seamless pace

			gameObject.position = Vector3.Lerp(gameObject.position, adjustmentParams, Time.deltaTime * adjustmentSpeed);
	}
}
