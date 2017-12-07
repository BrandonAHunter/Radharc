using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource music;
	public AudioSource SFX;

	// Update is called once per frame
	void Update () {
		if (music != null) {
			music.volume = GameManager.Instance.musicVolume;
		}
		if (SFX != null) {
			SFX.volume = GameManager.Instance.SFXVolume;
		}
	}
}
