using UnityEngine;
using System.Collections;

public class InputCapture : MonoBehaviour {

	int floorMask;
	float camRayLength = 100f;

	public PlayerController playerController;
	public WeaponHandler weaponHandler;
	public float AOEHoldDelay = .5f;

	private Vector3 initialClickPosition;
	private float initialClickTime;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) { //on left click

			initialClickPosition = getRayCastMousePosition();
			initialClickTime = Time.timeSinceLevelLoad;
		}

		if(Input.GetMouseButtonUp(0)){ //on left click release
			if(Vector3.Distance (getRayCastMousePosition(), initialClickPosition) > 2){
				//This is a swipe
				//compute the direction of the swipe
				Vector3 swipe = getRayCastMousePosition() - initialClickPosition;
				swipe.Normalize();
				playerController.StartAttack(swipe);
				weaponHandler.StartAttack (swipe);
				Debug.Log("SWIPE!");

			}else if(Time.timeSinceLevelLoad - initialClickTime < AOEHoldDelay ){
				//This is a tap, use it to navigate
				playerController.UpdateTargetPosition(initialClickPosition);
				Debug.Log("Got Click Event");
			}else{
				//This is a press and hold, activate the special
				Debug.Log ("Press and Hold");
				playerController.StartAreaAttack();
				weaponHandler.StartAOEAttack();
			}
		}
	}

	Vector3 getRayCastMousePosition()
	{
		Ray camRay;
		RaycastHit floorHit;

//#if UNITY_STANDALONE_WIN
		camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//#elif UNITY_ANDROID
//		camRay = Camera.main.ScreenPointToRay (Input.touches[0].position);
//#endif

//		if (Physics.Raycast(camRay,out floorHit,camRayLength, floorMask))
//		{
//			return floorHit.point;
//		}

		Debug.Log ("RayCast miss... this is bad");
		return Vector3.zero;
	}
}
