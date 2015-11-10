using UnityEngine;
using System.Collections;

	public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public float attackDamage = 10f;               
	public SphereCollider weaponCollider;
	public Rigidbody weaponbody;
	public float attackStartDelay = 1f;
	public float attackRange = 2f;
	public float attackDuration = .25f;
	//GameObject Body;

	public Animator anim;
	GameObject player;
	GameObject parentObject;
	                                        
	public EnemyHealth enemyHealth;                                             
	float timer;        
	float attackTimer;
	
	
	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag ("Player");
		weaponCollider.enabled = false;
		parentObject = this.transform.parent.gameObject;

	}

	
	
	void Update ()
	{


		
		float rangeToPlayer = Vector3.Distance (player.transform.position, parentObject.transform.position);

		if (rangeToPlayer < attackRange) {
			timer += Time.deltaTime;

			if (timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0) {
				weaponCollider.enabled = true;
				Attack ();
			}	
		} else {
			timer = timeBetweenAttacks - (timeBetweenAttacks - attackStartDelay);
		}

	}
	
	
	void Attack ()
	{
		anim.SetTrigger("Attack");
		attackTimer += Time.fixedDeltaTime;

		if (attackTimer >= attackDuration) {
			weaponCollider.enabled = false;
			timer = 0f;
			attackTimer = 0f;
		}
	}
}