using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {
	
	public SphereCollider weaponCollider;
	public float meleePower = 50f;

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate () {
//		weaponCollider.
//	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("PUNCH!");
		if (collision.gameObject.tag == "Enemy"){
			Rigidbody enemy = collision.gameObject.GetComponentInChildren<Rigidbody> ();
			Vector3 force = enemy.position - weaponCollider.transform.position;
			force.Normalize();
			force *= meleePower;
			enemy.velocity = new Vector3(10,10,0);
		}
	}
}
