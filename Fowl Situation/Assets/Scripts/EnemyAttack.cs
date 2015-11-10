using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	//Reference to Player Scripts
	 PlayerController playerController;
	//PlayerDamage playerDamage;


	//Weapon characteristics
	public SphereCollider weaponCollider;
	public Rigidbody weaponbody;

	//Weapon Properties
	//public float meleeRange = 1f;
	//public float meleePower = 50f;
	//public float meleeDuration = .1f;
	//public float meleeAnimDelay = .3f;
	public float distancefromPlayer;

	//private bool attacking = false;
	//private float attackStartTime;
	//private Vector3 attackVector; 

	private GameObject enemy;
	private GameObject player;

	public Animator anim;

	// Use this for initialization
	void Start () 
	{
	
		//playerController = (PlayerController)GameObject.FindObjectOfType (typeof(PlayerController));
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		weaponCollider.enabled = true;
		//playerController = gameObject.GetComponent<PlayerController> ();

		//anim = GetComponentInChildren<Animator> ();


	}
	
	// Update is called once per frame for physics object
	void Update () 
	{
		distancefromPlayer = Vector3.Distance (transform.position, player.transform.position);
		/*if (attacking) 
		{
			Attack();
		}
		*/
	}

	void OnTriggerStay(Collider other)
	{
		//playerController = other.gameObject.GetComponent<PlayerController> ();
		if (other.gameObject.tag == "Player" &&  distancefromPlayer < 1.7) {
			//playerController.takeDamage (0.01f);
			Debug.Log(player);
			Debug.Log(player.GetComponent<PlayerController>());
			playerController = player.GetComponent<PlayerController>();
			playerController.takeDamage(0.01f);


			anim.SetBool ("Attack", true);
		} 
		else 
		{
			anim.SetBool("Attack", false);
		}

	}


	/*
	public void StartAttack()
	{
		if (!attacking) 
		{
			attacking = true;
			attackStartTime = Time.timeSinceLevelLoad;
			//attackVector = meleeRange;

		}


	}

	void Attack()
	{
		if((Time.timeSinceLevelLoad - attackStartTime) > meleeAnimDelay && (Time.timeSinceLevelLoad - attackStartTime) < (meleeDuration + meleeAnimDelay))
		{
			weaponCollider.enabled = true;
			//weaponbody.position += attackVector;
			
		}
		else if ((Time.timeSinceLevelLoad - attackStartTime) > (meleeDuration + meleeAnimDelay)) 
		{
			weaponbody.velocity = new Vector3(0,0,0);
			weaponbody.position = player.transform.position + new Vector3 (0,1,0);
			attacking = false;
			weaponCollider.enabled = false;
			
			
		}

	}
	*/
}
