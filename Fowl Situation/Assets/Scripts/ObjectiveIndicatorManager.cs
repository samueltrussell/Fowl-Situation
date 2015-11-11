using UnityEngine;
using System.Collections;

public class ObjectiveIndicatorManager : MonoBehaviour {

	public GameObject player;
	private GameObject keyObjective, patsyObjective;
	public GameObject keyIndicator, patsyIndicator;

	private Vector3 headingToTarget;
	private Vector3 headingToPatsy;

	private GameObject target;
	private GameObject indicator;

	// Use this for initialization
	void Start () {
		keyObjective = GameObject.Find ("Objective Key");
		patsyObjective = GameObject.Find("The Patsy");

		target = keyObjective;
		indicator = keyIndicator;
	}
	
	// Update is called once per frame
	void Update () {

		if (keyObjective == null)
			SelectNextObjective ();

		if (target != null) {
			headingToTarget = target.transform.position - transform.position;
			headingToTarget.y = 0f;
			Quaternion newHeading = Quaternion.LookRotation (headingToTarget);
			Rigidbody indicatorBody = indicator.GetComponent<Rigidbody> ();
			indicatorBody.MoveRotation (newHeading);
		} else {
			Debug.Log("Warning! Objective is Null!");
		}

		transform.position = player.transform.position;
	}

	public void SelectNextObjective(){
		patsyObjective = GameObject.Find ("The Patsy");
		keyIndicator.SetActive (false);
		patsyIndicator.SetActive (true);
		target = patsyObjective;
		indicator = patsyIndicator;
	}
}
