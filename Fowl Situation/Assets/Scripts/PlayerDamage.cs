using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	
	public PlayerController playerController;
	public float attackDamage;
	//public Animator anim;

	void Awake()
	{
		//anim = GetComponent<Animator> ();
	
	}


	void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.tag == "EnemyWeapon") {
			Debug.Log ("Enemy Hit");
			//anim.SetBool ("Attack", true);
			playerController.takeDamage (attackDamage);
		}
		else 
		{
			//anim.SetBool ("Attack", false);
		}
	}
}