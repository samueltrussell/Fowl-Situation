using UnityEngine;
using System.Collections;

public class InputCapture : MonoBehaviour {

	int floorMask;
	float camRayLength = 100f;

	public PlayerController playerController;

	private Vector3 initialClickPosition;
	private Vector3 floorHit;
	private float initialClickTime;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) { //on left click
			//getPosition ();
			//Debug.Log("Got Click Event");

			initialClickPosition = getRayCastMousePosition();
			initialClickTime = Time.realtimeSinceStartup;
		}
		if(Input.GetMouseButtonUp(0)){ //on left click release
			if(Vector3.Distance (getRayCastMousePosition(), initialClickPosition) > 10){
				//This is a swipe
				//compute the direction of the swipe
				Vector3 swipe = getRayCastMousePosition() - initialClickPosition;
				swipe.Normalize();
				playerController.StartAttack (swipe);
				Debug.Log("SWIPE!");

			}else{
				floorHit = getRayCastMousePosition();
				playerController.UpdateTargetPosition(initialClickPosition);
				Debug.Log("Got Click Event");
			}
		}
	}

	Vector3 getRayCastMousePosition()
	{
		Ray camRay;
		RaycastHit floorHit;

#if UNITY_STANDALONE_WIN
		camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
#elif UNITY_ANDROID
		camRay = Camera.main.ScreenPointToRay (Input.touches[0].position);
#endif

//		if (Physics.Raycast(camRay,out floorHit,camRayLength, floorMask))
//		{
//			return floorHit.point;
//		}

		Debug.Log ("RayCast miss... this is bad");
		return Vector3.zero;
	}
}
