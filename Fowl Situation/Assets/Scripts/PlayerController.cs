using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public GameObject player, target;
	public float moveSpeed= 10f;
	public Animator anim;

	private Vector3 targetPosition;
	private Vector3 movement;
	private bool attacking = false;
	private Vector3 attackVector;
	private double attackStartTime;

	void Awake()
	{
		targetPosition = transform.position;
		//meleeWeaponBody = meleeWeapon.GetComponentInChildren<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (attacking)
			attack ();
		Move ();
	}

	void Move()
	{
		float error = Vector3.Distance (targetPosition, transform.position);

		if (error > .2) {
			movement = (targetPosition - transform.position);
			movement = movement.normalized * moveSpeed * Time.fixedDeltaTime;
			transform.position = (transform.position + movement);
		} else {
			movement = (targetPosition - transform.position);
			movement = movement.normalized * moveSpeed * error * Time.fixedDeltaTime;
			transform.position = (transform.position + movement);
		}

		if (error > 1) {
			anim.SetBool ("Walking", true);
		
		} else {
			anim.SetBool ("Walking", false);
		
		}

	}

	public void UpdateTargetPosition(Vector3 i_targetPosition)
	{
		targetPosition = i_targetPosition;
		target.transform.position = i_targetPosition + new Vector3(0,.2f,0);
	}

	public void StartAttack(Vector3 swipe)
	{

	}

	public void StartAreaAttack(){
	
	}

	public void attack()
	{

	}

}
