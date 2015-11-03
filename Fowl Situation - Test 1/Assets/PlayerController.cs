using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float speed;

	private Vector3 targetPosition;
	private Vector3 movement;


	void Awake()
	{
		targetPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
	}

	void Move(float h, float v)
	{
		movement = (targetPosition - transform.position);
		movement = movement.normalized * speed * Time.fixedDeltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

	}

	public void UpdateTargetPosition(Vector3 i_targetPosition)
	{
		targetPosition = i_targetPosition;
	}

}
