using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	
	public PlayerController playerController;
	//public Animator anim;

	void Awake()
	{
		//anim = GetComponent<Animator> ();
	
	}


	void OnTriggerStay(Collider collision)
	{

		if (collision.gameObject.tag == "EnemyWeapon") {
			Debug.Log ("In Trigger Stay");
			//anim.SetBool ("Attack", true);
			playerController.takeDamage (10);
		}
		else 
		{
			//anim.SetBool ("Attack", false);
		}
	}
}