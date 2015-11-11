using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {

	Animator anim;
	public bool isLaunchMessage = false;
	public GameObject nextObjective;
	public GameObject initObject;
	public float launchTime = 2;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isLaunchMessage) {
			if(Time.timeSinceLevelLoad > launchTime){
				anim.SetTrigger("Collected");
			}
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player") {
			anim.SetTrigger ("Collected");
		}
	}

	void KeyCollected()
	{
		if (isLaunchMessage) {
			Destroy (this.transform.parent.transform.parent.gameObject);
		} else {
			if (nextObjective != null){
				nextObjective.SetActive (true);
			}
			if(initObject!=null){
				initObject.SetActive(true);
			}
			Destroy (this.transform.parent.gameObject);

		}
	}

}
