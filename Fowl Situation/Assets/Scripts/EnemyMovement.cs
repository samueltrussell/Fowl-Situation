using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public EnemyHealth enemyhealth;
	public Animator anim;
	public float distancefromPlayer;
	
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
			nav.SetDestination (player.position);
			/*
			if(distancefromPlayer < 1.7  )
			{
				anim.SetBool("Attack",true);
			}
			else
			{
				anim.SetBool("Attack", false);
			}*/
		}

	}



}
