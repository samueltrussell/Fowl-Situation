using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	//public GameObject player;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		//player = GameObject.FindGameObjectWithTag("Player");


	}


	void Spawn()
	{


		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		


	}
	
		
}
