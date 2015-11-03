using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float followGain = 5f;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetPos, followGain * Time.fixedDeltaTime); 
	}
}
