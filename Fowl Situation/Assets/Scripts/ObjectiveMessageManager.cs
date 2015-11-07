using UnityEngine;
using System.Collections;

public class ObjectiveMessageManager : MonoBehaviour {

	public float lingerTime = 2;
	public bool win = false;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.timeSinceLevelLoad > (startTime + lingerTime)) {
			if(win){

			}else{
				Destroy (this.gameObject);
			}
		}
	}
}
