using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float speed;
//	public Animator anim;

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

		float error = Vector3.Distance (targetPosition, transform.position);

//		if (error > 1) {
//			anim.SetBool ("Walking", true);
//		
//		} else {
//			anim.SetBool ("Walking", false);
//		
//		}

	}

	public void UpdateTargetPosition(Vector3 i_targetPosition)
	{
		targetPosition = i_targetPosition;
	}

}
