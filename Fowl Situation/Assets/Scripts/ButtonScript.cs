using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	public Transform PauseButton;


	UIButton pauseButtonScript;

	private bool isPause = false;



	private Transform lifePoorForeground;
	
	UISlider lifePoorUISlider;

	float increaseSpeed;

	UISprite liftColorScript;


	Camera cam;	


	public Transform MenuBackground;

	Transform UI;


	public Transform BackgroundMusicVolumeSlider;
	UISlider BackgroundMusicVolumeSliderScript;
	
	public Transform SoundEffectVolumeSlider;
	UISlider SoundEffectVolumeSliderScript;

	AudioSource titleBackgroundMusic;
	AudioSource mouseClick;

	float clickAudioTime;

	public AudioClip [] clips;
	// Use this for initialization
	void Start () {
		SetupGUI ();
		SetupAudio ();

		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();

		iTween.CameraFadeAdd ();
	}


	void SetupGUI(){
		
		increaseSpeed = .05f;
		pauseButtonScript = PauseButton.GetComponent<UIButton> ();

		UI = GameObject.Find ("UI Root").transform;
		UI.gameObject.SetActive (true);
	}

	void SetupAudio(){

		BackgroundMusicVolumeSliderScript = BackgroundMusicVolumeSlider.GetComponent<UISlider> ();
		SoundEffectVolumeSliderScript = SoundEffectVolumeSlider.GetComponent<UISlider> ();
		
		
		titleBackgroundMusic = this.gameObject.AddComponent<AudioSource> ();
		titleBackgroundMusic.clip = this.clips[0];
		titleBackgroundMusic.loop = true;
		titleBackgroundMusic.Play ();
		
		mouseClick = this.gameObject.AddComponent<AudioSource> ();
		mouseClick.clip = this.clips [1];
		mouseClick.loop = false;


		BackgroundMusicVolumeSliderScript.value = SoundManager.SM.backgroundMusicVol;
		SoundEffectVolumeSliderScript.value = SoundManager.SM.soundEffectVol;
		
		titleBackgroundMusic.volume = BackgroundMusicVolumeSliderScript.value;
		mouseClick.volume = SoundEffectVolumeSliderScript.value;

		clickAudioTime = mouseClick.clip.length;
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
		SoundManager.SM.backgroundMusicVol =BackgroundMusicVolumeSliderScript.value ;
		SoundManager.SM.soundEffectVol = SoundEffectVolumeSliderScript.value;
		
		titleBackgroundMusic.volume = BackgroundMusicVolumeSliderScript.value;
		mouseClick.volume = SoundEffectVolumeSliderScript.value;
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

		UI.gameObject.SetActive (false);
		iTween.CameraFadeTo (iTween.Hash ("amount", 1, "time", 0.5, "oncomplete", "TitleScene", "oncompletetarget", gameObject));
	}

	void TitleScene() {
	
		Application.LoadLevel ("Title Scene");
	}
	                          
}
