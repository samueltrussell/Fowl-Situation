using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public float sinkspeed = 2.5f;


	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;



	Animator anim;
	void Awake()
	{
		anim = GetComponent<Animator> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();

		currentHealth = startingHealth;
	}

	// Update is called once per frame
	void Update () 
	{
	
		if (isSinking) 
		{
			transform.Translate(-Vector3.up * Time.deltaTime);
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
		capsuleCollider.isTrigger = true;

	}

	public void StartSinking()
	{
		//Disabling NavMeshAgent
		GetComponent<NavMeshAgent> ().enabled = false;

		GetComponent<Rigidbody> ().isKinematic = true;
		isSinking = true;

		//Destroy gameobject after 2 seconds
		Destroy (gameObject, 2f);

	}

}
