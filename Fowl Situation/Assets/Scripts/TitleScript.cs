using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	AudioSource titleBackgroundMusic;
	AudioSource mouseClick;
	public AudioClip [] clips;
	float clickAudioTime;

	public Transform BackgroundMusicVolumeSlider;
	UISlider BackgroundMusicVolumeSliderScript;

	public Transform SoundEffectVolumeSlider;
	UISlider SoundEffectVolumeSliderScript;


	bool isSettingButtonOn;
	public Transform Sliders;
	// Use this for initialization
	void Start () {
		SliderSetup ();

	}
	
	// Update is called once per frame
	void Update () {
		SliderUpdate ();
	}


	void SliderSetup(){
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
		SoundEffectVolumeSliderScript.value =SoundManager.SM.soundEffectVol;
		
		titleBackgroundMusic.volume = BackgroundMusicVolumeSliderScript.value;
		mouseClick.volume = SoundEffectVolumeSliderScript.value;


		clickAudioTime = mouseClick.clip.length;

	}

	void SliderUpdate(){
		SoundManager.SM.backgroundMusicVol = BackgroundMusicVolumeSliderScript.value;
		SoundManager.SM.soundEffectVol = SoundEffectVolumeSliderScript.value;
		
		titleBackgroundMusic.volume = BackgroundMusicVolumeSliderScript.value;
		mouseClick.volume = SoundEffectVolumeSliderScript.value;


	}


		
	
	



	public void NewGame(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		StartCoroutine(NewGameScene());
	}

	IEnumerator NewGameScene() {
		yield return new WaitForSeconds(clickAudioTime);
		Application.LoadLevel ("Hang's Workshop");
	}


	public void Toturial(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		StartCoroutine(ToturialScene());
	}

	IEnumerator ToturialScene() {
		yield return new WaitForSeconds(clickAudioTime);
		Application.LoadLevel ("Hang's Workshop");   // change to toturial later~
	}

	public void Setting(){
		if (!mouseClick.isPlaying)
			mouseClick.Play ();

		if (!isSettingButtonOn) {		// is on
			Sliders.gameObject.SetActive (true);

		} else {
			Sliders.gameObject.SetActive (false);
		}
		
		isSettingButtonOn = !isSettingButtonOn;	
	}

	public void Exit(){
		Application.LoadLevel ("Title Scene");
	}


}
