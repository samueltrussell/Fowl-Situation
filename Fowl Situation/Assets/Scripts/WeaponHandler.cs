﻿using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {
	
	public SphereCollider weaponCollider;
	//public Rigidbody weaponBody;
	public Transform weaponTransform;
	public float meleeRange = 1f;
	public float meleePower = 50f;
	public float meleeDuration = .1f;
	public float meleeAnimDelay = .3f;

	public float AOERange = 3f;
	public float AOEPower = 50f;
	public float AOEDuration = 1f;
	public float AOEAnimDelay = .3f;

	//Sound Manager
	private PlayerSoundManager soundManager;

	private bool attacking = false;
	private float attackStartTime;
	private Vector3 attackVector;

	private EnemyHealth enemyHealth;

	private GameObject player;

	enum AttackType{
		AOEAttack,
		meleeAttack,
		Gun
	}

	AttackType attackType;
    
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		soundManager = GetComponent<PlayerSoundManager> ();
		weaponCollider.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (attacking)
			Attack ();
	}

	void OnTriggerEnter(Collider collision){

		enemyHealth = collision.gameObject.GetComponent<EnemyHealth> ();

		switch (attackType) {
		case AttackType.AOEAttack:
			Debug.Log ("AOE Attack!");
			if (collision.gameObject.tag == "Enemy") {
				Rigidbody enemy = collision.gameObject.GetComponentInChildren<Rigidbody> ();
				Vector3 force = enemy.position - weaponCollider.transform.position;
				force.Normalize ();
				force *= AOEPower;
				enemy.AddForce (force, ForceMode.Impulse);
				enemyHealth.TakeDamage(5);

				//SFX
				soundManager.spinHitSound();
			}
			break;
		case AttackType.meleeAttack:
			Debug.Log ("PUNCH!");
			if (collision.gameObject.tag == "Enemy") {
				Rigidbody enemy = collision.gameObject.GetComponentInChildren<Rigidbody> ();
				Vector3 force = attackVector;
				force.Normalize ();
				force *= meleePower;
				enemy.AddForce (force, ForceMode.Impulse);
				enemyHealth.TakeDamage(10);

				//SFX
				soundManager.punchHitSound();
			}
			break;
		}
	}

	public void StartAttack(Vector3 swipe)
	{
		if (player.GetComponent<PlayerController>().alive) {
			if (!attacking) {
				attacking = true;
				attackType = AttackType.meleeAttack;
				attackStartTime = Time.timeSinceLevelLoad;
				attackVector = swipe * meleeRange;

			}
		}
	}

	public void StartAOEAttack(){
		if (player.GetComponent<PlayerController> ().alive) {
			if (!attacking) {
				attacking = true;
				attackType = AttackType.AOEAttack;
				attackStartTime = Time.timeSinceLevelLoad;

			}
		}
	}
	
	public void Attack()
	{

		switch (attackType) {
		case AttackType.AOEAttack:


			if((Time.timeSinceLevelLoad - attackStartTime) > AOEAnimDelay && (Time.timeSinceLevelLoad - attackStartTime) < (AOEDuration + AOEAnimDelay)){
				weaponCollider.enabled = true;
				weaponCollider.radius = AOERange;

			}
			else if ((Time.timeSinceLevelLoad - attackStartTime) > (AOEDuration + AOEAnimDelay)) {
				weaponCollider.radius = .5f;
				weaponCollider.enabled = false;
				attacking = false;
			}
			break;
		case AttackType.meleeAttack:
			if((Time.timeSinceLevelLoad - attackStartTime) > meleeAnimDelay && (Time.timeSinceLevelLoad - attackStartTime) < (meleeDuration + meleeAnimDelay)){
				weaponCollider.enabled = true;
				weaponTransform.position = player.transform.position + attackVector + new Vector3(0,1,0);
			}
			else if ((Time.timeSinceLevelLoad - attackStartTime) > (meleeDuration + meleeAnimDelay)) {
				weaponTransform.position = player.transform.position + new Vector3 (0,1,0);
				attacking = false;
				weaponCollider.enabled = false;
			}
			break;
		case AttackType.Gun:
			break;
		}


	}
}
