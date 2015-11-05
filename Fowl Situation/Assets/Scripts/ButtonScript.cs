using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	public Transform PauseButton;

	//用来检测是否开启划线（防止小bug）
	UIButton pauseButtonScript;

	private bool isPause = false;


	public Transform lifePoor;

	private Transform lifePoorForeground;
	
	UISlider lifePoorUISlider;

	float increaseSpeed;
	//获取能量条控制颜色的脚本
	UISprite liftColorScript;


	Camera cam;	


	public Transform MenuBackground;

	// Use this for initialization
	void Start () {
	

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

	void CheckPauseButtonStatus(){
//		if (pauseButtonScript.state == UIButtonColor.State.Hover || pauseButtonScript.state == UIButtonColor.State.Pressed) {

			
//		} else {

//		}

	}

	public void PauseButtonTrigger(){
		if (!isPause) {		// is playing
			PauseButton.gameObject.SetActive (false);
			MenuBackground.gameObject.SetActive (true);
			Time.timeScale = 0f;	
		}
		
		isPause = !isPause;	
	}

	public void PlayButtonTrigger(){
		if (isPause) {	
			
			PauseButton.gameObject.SetActive (true);
			MenuBackground.gameObject.SetActive (false);
			Time.timeScale = 1f;
		}
		
		isPause = !isPause;	
	}

	public void RetryButtonTrigger(){
		Time.timeScale = 1f;
		Application.LoadLevel ("Hang's Workshop");

	}

	public void ExitButtonTrigger(){
		Application.LoadLevel ("Hang's Workshop");
	}
	                          
}
