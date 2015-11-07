using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public EnemyHealth enemyhealth;

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
	}

}
