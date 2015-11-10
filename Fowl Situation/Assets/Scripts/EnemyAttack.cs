using UnityEngine;
using System.Collections;
/*
public class EnemyAttack : MonoBehaviour {


	//Reference to Player Scripts
	public PlayerController playerController;
	PlayerDamage playerDamage;


	//Weapon characteristics
	public SphereCollider weaponCollider;
	public Rigidbody weaponbody;
	public float distancefromPlayer;

	//Weapon Properties
	public float meleeRange = 1f;
	public float meleePower = 50f;
	public float meleeDuration = .1f;
	public float meleeAnimDelay = .3f;


	private bool attacking = false;
	private float attackStartTime;
	//private Vector3 attackVector; 

	private GameObject enemy;
	private GameObject player;


	public Animator anim;

	// Use this for initialization
	void Start () 
	{
	
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		weaponCollider.enabled = true;
		//anim = GetComponentInChildren<Animator> ();


	}

	void Update()
	{
		distancefromPlayer = Vector3.Distance (transform.position, player.transform.position);
	}

	// Update is called once per frame for physics object
	void FixedUpdate () 
	{
		if (attacking) 
		{
			Attack();
		}
	
	}

	/*void OnTriggerStay(Collider other)
	{
		//playerController = other.gameObject.GetComponent<PlayerController> ();
		if (other.gameObject.tag == "Player" && distancefromPlayer < 1.9) {
			anim.SetBool ("Attack", true);
			playerController.takeDamage(0.01f);
		} 
		else 
		{
			anim.SetBool ("Attack", false);
		
		}

	}

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
}
*/




	public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public float attackDamage = 10f;               
	public SphereCollider weaponCollider;
	public Rigidbody weaponbody;
	//GameObject Body;

	public Animator anim;
	GameObject player;
	                          
	public PlayerController playerController;                 
	public EnemyHealth enemyHealth;                    
	bool playerInRange;                         
	float timer;                                
	
	
	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponentInParent <PlayerController> ();
		weaponCollider.enabled = true;

	}

	
	void OnTriggerEnter (Collider other)
	{

		if(other.gameObject == player)
		{
			Debug.Log ("Entered");

			playerInRange = true;
			anim.SetBool("Attack", true);
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{

		if(other.gameObject == player)
		{

			playerInRange = false;
			anim.SetBool("Attack",false);
		}
	}
	
	
	void Update ()
	{

		timer += Time.deltaTime;
		

		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{

			Attack ();
		}

	}
	
	
	void Attack ()
	{

		timer = 0f;
		

		if(playerController.playerHealth > 0)
		{
			playerController.takeDamage (attackDamage);
		}
	}
}