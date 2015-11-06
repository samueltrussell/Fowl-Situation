using UnityEngine;
using System.Collections;


public class SpawnPoint : MonoBehaviour {
	
	public float distancefromPlayer;
	public float spawnTime = 3f;
	private EnemyManager EM;
	private GameObject player;
	
	public GameObject enemy;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		EM = transform.parent.GetComponent<EnemyManager>();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
		// Update is called once per frame
	void Update () 
	{
		
		distancefromPlayer = Vector3.Distance (transform.position, player.transform.position);
		
		
		
	}

	//Spawn Function

	void Spawn(){
	
	if ((EM.totalEnemies < EM.numberOfEnemies) && (distancefromPlayer > 20)) 
	{
		Instantiate (enemy, transform.position, enemy.transform.rotation);
		EM.totalEnemies++;
		Debug.Log ("Enemies Spawned "+EM.totalEnemies);
	}
}
}
