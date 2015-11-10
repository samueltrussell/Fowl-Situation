using UnityEngine;
using System.Collections;

public class SoundManager {
	
	public float backgroundMusicVol;

	public float soundEffectVol;

	public bool isChangeVol;

	private static SoundManager sm=null;

	public static SoundManager SM
	{
		get{
			if (sm == null) {
				sm = new SoundManager ();
			}
			return sm;
		}
	}


	private SoundManager()
	{
		backgroundMusicVol = 0.65f;
		soundEffectVol = 0.65f;
		isChangeVol = false;
	}


	
}