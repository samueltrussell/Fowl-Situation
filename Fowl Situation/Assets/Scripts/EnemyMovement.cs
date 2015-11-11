using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public EnemyHealth enemyhealth;
	public Animator anim;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if (enemyhealth.currentHealth > 0) 
		{
			nav.SetDestination (player.position);
		}

		if (Vector3.Distance(player.position, transform.position) > nav.stoppingDistance)
			anim.SetBool ("Walking", true);
		else
			anim.SetBool ("Walking", false);

	}



}
