using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public int scoreValue = 10;


	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isFlying;


	void Awake()
	{
		capsuleCollider = GetComponent<CapsuleCollider> ();
		currentHealth = startingHealth;
	
	}

	// Update is called once per frame
	void Update () 
	{
	
		if (isFlying) 
		{
			transform.Translate(Vector3.up * Time.deltaTime);
		}

	}

	public void TakeDamage(int amount)
	{
		if (isDead)
			return;

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
}
