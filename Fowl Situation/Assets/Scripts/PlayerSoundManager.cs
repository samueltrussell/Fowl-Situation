using UnityEngine;
using System.Collections;

public class PlayerSoundManager : MonoBehaviour {

	public AudioClip punchWhiff;
	public AudioClip punchCluckHit;
	public AudioClip punchNoCluck;	
	public AudioClip spinWhiff;
	public AudioClip spinHit;
	public AudioClip idleClucking;
	public AudioClip deathRattle;
	public AudioSource audioSource;



	// Use this for initialization
	void Start () {
		//audioSource = GetComponent<AudioSource> ();
	}

	void idleSound()
	{
		int chance = Random.Range (0, 10);
		if (chance == 1) {
			playIdleClucking();
		}

	}

	void playIdleClucking()
	{
		audioSource.clip = idleClucking;
		audioSource.Play();
	}

	public void punchHitSound()
	{
		if (Random.Range (0, 3) == 1) {
			audioSource.PlayOneShot (punchCluckHit);
		} 
		//else {
			audioSource.PlayOneShot (punchNoCluck);
		//}
	}

	public void spinHitSound()
	{
		audioSource.PlayOneShot (spinHit);
	}

	void playPunchWhiff()
	{
		audioSource.PlayOneShot (punchWhiff);
	}

	void playPunchCluckHit()
	{
		audioSource.PlayOneShot (punchCluckHit);
	}

	void playPunchNoCluck()
	{
		audioSource.PlayOneShot (punchNoCluck);
	}

	void playSpinWhiff()
	{
		audioSource.PlayOneShot (spinWhiff);
	}

	void playSpinHit()
	{
		audioSource.PlayOneShot (spinHit);
	}

	void playDeathRattle()
	{
		audioSource.PlayOneShot (deathRattle);
	}
}
