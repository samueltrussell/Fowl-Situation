using UnityEngine;
using System.Collections;

public class InputCapture : MonoBehaviour {

	int floorMask;
	float camRayLength = 100f;

	public PlayerController playerController;


	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			getPosition ();
			Debug.Log("Got Click Event");
		}
	}

	void getPosition()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay,out floorHit,camRayLength, floorMask))
		{
			playerController.UpdateTargetPosition(floorHit.point);
		}
	}


}
