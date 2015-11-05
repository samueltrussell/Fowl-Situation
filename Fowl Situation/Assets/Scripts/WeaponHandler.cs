using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {
	
	public SphereCollider weaponCollider;
	public Rigidbody weaponBody;
	public float meleeRange = 1f;
	public float meleePower = 50f;
	public float meleeDuration = .1f;

	public float AOERange = 3f;
	public float AOEPower = 50f;
	public float AOEDuration = 1f;

	private bool attacking = false;
	private double attackStartTime;
	private Vector3 attackVector;

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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (attacking)
			Attack ();
	}

	void OnCollisionEnter(Collision collision){
		switch (attackType) {
		case AttackType.AOEAttack:
			Debug.Log ("AOE Attack!");
			if (collision.gameObject.tag == "Enemy") {
				Rigidbody enemy = collision.gameObject.GetComponentInChildren<Rigidbody> ();
				Vector3 force = enemy.position - weaponCollider.transform.position;
				force.Normalize ();
				force *= AOEPower;
				enemy.AddForce (force, ForceMode.Impulse);
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
			}
			break;
		}
	}

	public void StartAttack(Vector3 swipe)
	{
		if (!attacking) {
			attacking = true;
			attackType = AttackType.meleeAttack;
			attackStartTime = Time.realtimeSinceStartup;
			attackVector = swipe * meleeRange;
			weaponBody.position += attackVector;
		}
	}

	public void StartAOEAttack(){
		if (!attacking) {
			attacking = true;
			attackType = AttackType.AOEAttack;
			attackStartTime = Time.realtimeSinceStartup;
			weaponCollider.radius = AOERange;
		}
	}
	
	public void Attack()
	{
		switch (attackType) {
		case AttackType.AOEAttack:
			if (Time.realtimeSinceStartup - attackStartTime > AOEDuration) {
				weaponCollider.radius = .5f;
				attacking = false;
			}
			break;
		case AttackType.meleeAttack:
			if (Time.realtimeSinceStartup - attackStartTime > meleeDuration) {
				weaponBody.velocity = new Vector3(0,0,0);
				weaponBody.position = player.transform.position + new Vector3 (0,1,0);
				attacking = false;
			}
			break;
		case AttackType.Gun:
			break;
		}


	}
}
