using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	public Transform PauseButton;


	UIButton pauseButtonScript;

	private bool isPause = false;


	public Transform lifePoor;

	private Transform lifePoorForeground;
	
	UISlider lifePoorUISlider;

	float increaseSpeed;

	UISprite liftColorScript;


	Camera cam;	


	public Transform MenuBackground;


	AudioSource mouseClick;
	public AudioClip clip;
	// Use this for initialization
	void Start () {
		SetupGUI ();
		SetupAudio ();

		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}


	void SetupGUI(){
		lifePoorUISlider = lifePoor.gameObject.GetComponent<UISlider> ();
		lifePoorUISlider.value = 0.0f;
		
		increaseSpeed = .05f;
		pauseButtonScript = PauseButton.GetComponent<UIButton> ();
		
		//initialize the color of life poor
		lifePoorForeground = lifePoor.Find ("Foreground").transform;

		//get the script to control the color of life poor
		liftColorScript = lifePoorForeground.GetComponent<UISprite> ();

	}

	void SetupAudio(){
		mouseClick = gameObject.AddComponent<AudioSource> ();
		mouseClick.clip = this.clip;
		mouseClick.loop = false;
	}

	// Update is called once per frame
	void Update () {
		ControlLife ();

		ChangeVolume ();  
		
		//check if it paused, if it is in the stop status tap the screen can not trigger any function
		CheckPauseButtonStatus ();	


		
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			//Debug.Log (hit.transform.name);
			if (hit.transform.name == "UI Root") {

				
			}
		} else {

		}
	}

	void ControlLife(){

	}

	void ChangeVolume(){

	}

	void CheckPauseButtonStatus(){  // need work
//		if (pauseButtonScript.state == UIButtonColor.State.Hover || pauseButtonScript.state == UIButtonColor.State.Pressed) {

			
//		} else {


	
//      }
	


	}

	public void PauseButtonTrigger(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		if (!isPause) {		// is playing
			PauseButton.gameObject.SetActive (false);
			MenuBackground.gameObject.SetActive (true);
			Time.timeScale = 0f;	
		}
		
		isPause = !isPause;	
	}

	public void PlayButtonTrigger(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		if (isPause) {	
			
			PauseButton.gameObject.SetActive (true);
			MenuBackground.gameObject.SetActive (false);
			Time.timeScale = 1f;
		}
		
		isPause = !isPause;	


	}

	public void RetryButtonTrigger(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		Time.timeScale = 1f;
		Application.LoadLevel ("Hang's Workshop");

	}

	public void ExitButtonTrigger(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		Application.LoadLevel ("Hang's Workshop");
	}
	                          
}
