using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	
	public PlayerController playerController;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "EnemyWeapon") {
			playerController.takeDamage(5);
		}
	}
}
