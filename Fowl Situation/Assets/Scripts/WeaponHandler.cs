using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {
	
	public SphereCollider weaponCollider;
	public Rigidbody weaponBody;
	public float meleeRange = 1f;
	public float meleePower = 50f;
	public float meleeDuration = .1f;
	public float meleeAnimDelay = .3f;

	public float AOERange = 3f;
	public float AOEPower = 50f;
	public float AOEDuration = 1f;
	public float AOEAnimDelay = .3f;

	//Sound files
	public AudioClip punchWhiff;
	public AudioClip punchCluckHit;
	public AudioClip spinWhiff;
	public AudioClip spinHit;
	public AudioSource hitAudio;
	public AudioSource swingAudio;

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
		weaponCollider.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (attacking)
			Attack ();
	}

	void OnCollisionEnter(Collision collision){

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

				//hitAudio.clip = punchCluckHit;
				hitAudio.PlayOneShot(spinHit);
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

				//hitAudio.clip = punchCluckHit;
				hitAudio.PlayOneShot(punchCluckHit);
			}
			break;
		}
	}

	public void StartAttack(Vector3 swipe)
	{
		if (!attacking) {
			attacking = true;
			attackType = AttackType.meleeAttack;
			attackStartTime = Time.timeSinceLevelLoad;
			attackVector = swipe * meleeRange;
//			weaponBody.position += attackVector;
		}
	}

	public void StartAOEAttack(){
		if (!attacking) {
			attacking = true;
			attackType = AttackType.AOEAttack;
			attackStartTime = Time.timeSinceLevelLoad;
		}
	}
	
	public void Attack()
	{

		switch (attackType) {
		case AttackType.AOEAttack:


			if((Time.timeSinceLevelLoad - attackStartTime) > AOEAnimDelay && (Time.timeSinceLevelLoad - attackStartTime) < (AOEDuration + AOEAnimDelay)){
				weaponCollider.enabled = true;
				weaponCollider.radius = AOERange;

				//Play Audio
				//swingAudio.clip = spinWhiff;
				//swingAudio.Play ();
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
				weaponBody.position += attackVector;

				//Play Audio
				swingAudio.clip = punchWhiff;
				swingAudio.Play ();

			}
			else if ((Time.timeSinceLevelLoad - attackStartTime) > (meleeDuration + meleeAnimDelay)) {
				weaponBody.velocity = new Vector3(0,0,0);
				weaponBody.position = player.transform.position + new Vector3 (0,1,0);
				attacking = false;
				weaponCollider.enabled = false;
			}
			break;
		case AttackType.Gun:
			break;
		}


	}
}
