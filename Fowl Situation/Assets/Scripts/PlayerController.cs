﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//public Rigidbody playerRigidbody;
	public GameObject player, target;
	public GameObject meleeWeapon;
	public float speed= 10f;
	public float meleeStrength = 5f;
	public float meleeDuration = .5f;
	public float meleeRange = .5f;
	public Animator anim;

	private Vector3 targetPosition;
	private Vector3 movement;
	private bool attacking = false;
	private Vector3 attackVector;
	private Rigidbody meleeWeaponBody;
	private double attackStartTime;

	void Awake()
	{
		targetPosition = transform.position;
		meleeWeaponBody = meleeWeapon.GetComponentInChildren<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
//		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");

		if (attacking)
			attack ();
		Move ();
	}

	void Move()
	{
		float error = Vector3.Distance (targetPosition, transform.position);

		if (error > .2) {
			movement = (targetPosition - transform.position);
			movement = movement.normalized * speed * Time.fixedDeltaTime;
			transform.position = (transform.position + movement);
		} else {
			movement = (targetPosition - transform.position);
			movement = movement.normalized * speed * error * Time.fixedDeltaTime;
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
		attacking = true;
		attackStartTime = Time.realtimeSinceStartup;
		attackVector = swipe * meleeRange;

		meleeWeaponBody.position += attackVector;
	}

	public void attack()
	{
		if (Time.realtimeSinceStartup - attackStartTime > meleeDuration) {
			meleeWeaponBody.velocity = new Vector3(0,0,0);
			meleeWeaponBody.position = transform.position + new Vector3 (0,1,0);
			attacking = false;
		}
		//swipe *= meleeStrength;
	}

}
