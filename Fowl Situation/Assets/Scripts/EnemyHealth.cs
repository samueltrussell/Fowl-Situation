using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public float sinkspeed = 2.5f;
	float timeOfDeath;
	public float tSink  = 4f;
	GameObject em;
	public bool Patsy = false;
	public GameObject winMessage;


	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;

	bool already = false;


//	Animator anim;
	void Awake()
	{
		//anim = GetComponent<Animator> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();
		em = GameObject.FindGameObjectWithTag ("EnemyManager");
		currentHealth = startingHealth;
	}

	// Update is called once per frame
	void Update () 
	{
	
		if (isSinking) 
		{
			StartSinking();
		}

	}

	public void TakeDamage(int amount)
	{
		if (isDead)
			return;

		//Reduce the health
		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			Death();
		}

	}

	void Death()
	{
		isDead = true;
		Rigidbody enemyBody = this.gameObject.GetComponent<Rigidbody> ();// = RigidbodyConstraints.None;
		enemyBody.constraints = RigidbodyConstraints.None;

		//Disabling NavMeshAgent
		GetComponent<NavMeshAgent> ().enabled = false;
		timeOfDeath = Time.timeSinceLevelLoad;
		StartSinking ();

	}

	public void StartSinking()
	{
		//Disabling NavMeshAgent
//		GetComponent<NavMeshAgent> ().enabled = false;


		isSinking = true;
		if ((Time.timeSinceLevelLoad - timeOfDeath) > tSink) 
		{
			if(!already)
			{
				//GetComponent<Rigidbody> ().isKinematic = true;
				capsuleCollider.isTrigger = true;
				Destroy (gameObject, 4f);
				if(!Patsy){
					em.GetComponent<EnemyManager>().totalEnemies--;
				}else if (Patsy){
					if(winMessage != null){
						winMessage.SetActive(true);
					}
				}
				already = true;
			}
			//transform.Translate(-Vector3.up * Time.deltaTime);

		}
		//Destroy gameobject after 2 seconds


	}

}
