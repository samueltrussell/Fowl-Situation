﻿using UnityEngine;
using System.Collections;

public class PatsyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	Animator anim;

	public EnemyHealth enemyhealth;
	public float flightArrestDistance = 1f;
	public float flightDistance = 10f;
	public float targetDistance = 15f;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponentInChildren<Animator> ();

	}

	void Update()
	{
		if (enemyhealth.currentHealth > 0) 
		{
			float rangeToPlayer = Vector3.Distance(player.position, transform.position);

			if(rangeToPlayer < flightDistance && rangeToPlayer > flightArrestDistance){
				Vector3 headingToPlayer = player.position - transform.position;
				headingToPlayer.Normalize();
				Vector3 flightPoint = - targetDistance * headingToPlayer;
				nav.SetDestination(flightPoint);
			
			}else if (rangeToPlayer < flightArrestDistance){
				nav.SetDestination(transform.position);
			}else{
				//nav.setDestination();
			}
		}

		if (nav.velocity.magnitude > .25)
			anim.SetBool ("Walking", true);
		else
			anim.SetBool ("Walking", false);

	}

}
